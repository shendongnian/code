    Option Explicit On
    Option Strict On
    Imports System
    Imports EnvDTE
    Imports EnvDTE80
    Imports System.Collections.Generic
    Imports System.Linq
    Imports System.Text.RegularExpressions
    Imports System.Windows.Forms
    
    Friend Module InitializeAllMembers
        Public DTE As EnvDTE80.DTE2
        Private ReadOnly _usings As New HashSet(Of String)
    
        Sub InitializeAllMembers(ByVal getValue As Boolean)
            Try
                Dim memberAssignment As Func(Of String, String, String, EnvDTE.CodeTypeRef, String) = Nothing
                Dim selection As EnvDTE.TextSelection = CType(DTE.ActiveDocument.Selection(), EnvDTE.TextSelection)
                Dim editPoint As EditPoint = selection.BottomPoint.CreateEditPoint
    
                editPoint.StartOfLine()
    
                Dim className As String = ""
                Dim indent As String = ""
                Dim variable As String = ""
                Dim parseError As String
    
                If DTE.ActiveDocument.ProjectItem Is Nothing Then
                    MessageBox.Show("File does not belong to a project")
                End If
    
                If DTE.ActiveDocument.Language = "Basic" Then
                    parseError = GetVbInitialization(editPoint.GetText(editPoint.LineLength), className, indent, variable)
                    If getValue Then
                        memberAssignment = AddressOf VbMemberGetValue
                    Else
                        memberAssignment = AddressOf VbMemberAssignment
                    End If
                ElseIf DTE.ActiveDocument.Language = "CSharp" Then
                    parseError = GetCSharpInitialization(editPoint.GetText(editPoint.LineLength), className, indent, variable)
                    If getValue Then
                        memberAssignment = AddressOf CSharpMemberGetValue
                    Else
                        memberAssignment = AddressOf CSharpMemberAssignment
                    End If
                Else
                    parseError = "Not supported language " & DTE.ActiveDocument.Language
                End If
    
                If parseError IsNot Nothing Then
                    MessageBox.Show(parseError)
                    Exit Sub
                End If
    
                Dim currentFunction As CodeElement = FindCodeElement(selection.ActivePoint, DTE.ActiveDocument.ProjectItem.FileCodeModel.CodeElements)
                If currentFunction Is Nothing Then
                    MessageBox.Show("Can't find current function")
                    Exit Sub
                End If
                _usings.Clear()
                FindAllUsings(currentFunction)
    
                Dim classType As CodeElement = DTE.Solution.Projects.Cast(Of Project) _
                                                                    .Select(Function(x) FindClassInProjectItems(x.ProjectItems, className)) _
                                                                    .FirstOrDefault(Function(x) x IsNot Nothing)
    
                If classType Is Nothing Then
                    MessageBox.Show("Can't find type in solution: " & className)
                    Exit Sub
                End If
    
                DTE.UndoContext.Open("InitializeAllMembers")
                PrintMemberAssignments(memberAssignment, editPoint, indent, variable, GetMembers(classType))
                If TypeOf classType Is CodeClass Then
                    For Each base As CodeElement In CType(classType, CodeClass).Bases
                        If TypeOf base Is CodeClass Then
                            PrintMemberAssignments(memberAssignment, editPoint, indent, variable, GetMembers(base))
                        End If
                    Next
                End If
                DTE.UndoContext.Close()
            Catch objException As System.Exception
                MessageBox.Show(objException.Message)
            End Try
        End Sub
    
        Private Function GetVbInitialization(ByVal line As String, _
                                             ByRef className As String, _
                                             ByRef indent As String, _
                                             ByRef variable As String) As String
            Dim vbinitialization As New Regex("(?<Indent>\s*)Dim\s+(?<VariableName>[\S=]+)\s+(?:As\s+(?:New\s+)?(?<DeclaredType>[^\s\(]+))?(?:\s*=\s*New\s+(?<CreatedType>[^\s\(]+))?", _
                                              RegexOptions.IgnoreCase)
            Dim match As Match = vbinitialization.Match(line)
            If Not match.Success Then
                Return "No assignment on row"
            End If
            Dim foundDeclaredType As Boolean = match.Groups("DeclaredType").Success
            Dim foundCreatedType As Boolean = match.Groups("CreatedType").Success
            If Not (foundDeclaredType OrElse foundCreatedType) Then
                Return "Can't find type on row"
            End If
            className = If(foundDeclaredType, match.Groups("DeclaredType"), match.Groups("CreatedType")).Value
            indent = match.Groups("Indent").Value
            variable = match.Groups("VariableName").Value
            Return Nothing
        End Function
    
        Private Function GetCSharpInitialization(ByVal line As String, _
                                                 ByRef className As String, _
                                                 ByRef indent As String, _
                                                 ByRef variable As String) As String
            Dim csharpinitialization As New Regex("(?<Indent>\s*)(?:(?<DeclaredType>\S+)\s+)?(?<VariableName>[\S=]+)\s*=\s*(?<new>new)?\s*(?<CreatedType>[^\s\(]+)")
            Dim match As Match = csharpinitialization.Match(line)
            If Not match.Success Then
                Return "No assignment on row"
            End If
            Dim foundDeclaredType As Boolean = match.Groups("DeclaredType").Success AndAlso match.Groups("DeclaredType").Value <> "var"
            Dim foundCreatedType As Boolean = match.Groups("new").Success
            If Not (foundDeclaredType OrElse foundCreatedType) Then
                Return "Can't find type on row"
            End If
            className = If(foundDeclaredType, match.Groups("DeclaredType"), match.Groups("CreatedType")).Value
            indent = match.Groups("Indent").Value
            variable = match.Groups("VariableName").Value
            Return Nothing
        End Function
    
        Sub FindAllUsings(ByVal elem As Object)
            If TypeOf elem Is CodeFunction Then
                FindAllUsings(CType(elem, CodeFunction).Parent)
            ElseIf TypeOf elem Is CodeClass Then
                _usings.Add(CType(elem, CodeClass).FullName)
                FindAllUsings(CType(elem, CodeClass).Parent)
            ElseIf TypeOf elem Is CodeStruct Then
                _usings.Add(CType(elem, CodeStruct).FullName)
                FindAllUsings(CType(elem, CodeStruct).Parent)
            ElseIf TypeOf elem Is CodeNamespace Then
                _usings.Add(CType(elem, CodeNamespace).FullName)
                For Each ns As String In CType(elem, CodeNamespace).Members.OfType(Of CodeImport) _
                                                                           .Select(Function(x) x.Namespace)
                    _usings.Add(ns)
                Next
                FindAllUsings(CType(elem, CodeNamespace).Parent)
            ElseIf TypeOf elem Is FileCodeModel Then
                For Each ns As String In CType(elem, FileCodeModel).CodeElements.OfType(Of CodeImport) _
                                                                                .Select(Function(x) x.Namespace)
                    _usings.Add(ns)
                Next
            End If
        End Sub
    
        Public Function FindCodeElement(ByVal caretPosition As TextPoint, ByVal elems As CodeElements) As CodeElement
            If elems Is Nothing Then Return Nothing
            Return elems.Cast(Of CodeElement) _
                        .Where(Function(x) x.StartPoint.LessThan(caretPosition) AndAlso _
                                           x.EndPoint.GreaterThan(caretPosition)) _
                        .Select(Function(x) If(FindCodeElement(caretPosition, GetMembers(x)), x)) _
                        .FirstOrDefault()
        End Function
    
        Public Sub PrintMemberAssignments(ByVal memberAssignment As Func(Of String, String, String, CodeTypeRef, String), _
                                          ByVal editPoint As EditPoint, _
                                          ByVal indent As String, _
                                          ByVal variable As String, _
                                          ByVal members As CodeElements)
            For Each member As CodeElement In members
                Dim typeref As EnvDTE.CodeTypeRef
                If TypeOf member Is CodeProperty2 Then
                    Dim prop As CodeProperty2 = CType(member, CodeProperty2)
                    If prop.Setter Is Nothing Then
                        If prop.Access <> vsCMAccess.vsCMAccessPublic Then Continue For
                        If prop.ReadWrite = vsCMPropertyKind.vsCMPropertyKindReadOnly Then Continue For
                        If prop.IsShared Then Continue For
                    ElseIf prop.Setter.Access <> vsCMAccess.vsCMAccessPublic Then
                        Continue For
                    ElseIf prop.Setter.IsShared Then
                        Continue For
                    End If
                    typeref = prop.Type
                ElseIf TypeOf member Is CodeVariable Then
                    Dim var As CodeVariable = CType(member, CodeVariable)
                    If var.Access <> vsCMAccess.vsCMAccessPublic Then Continue For
                    If var.IsConstant Then Continue For
                    If var.IsShared Then Continue For
                    typeref = var.Type
                Else
                    Continue For
                End If
    
                editPoint.EndOfLine()
                editPoint.Insert(ControlChars.NewLine)
                editPoint.Insert(memberAssignment(indent, variable, member.Name, typeref))
            Next
        End Sub
    
        Private Function TrimKnownNamespace(ByVal fullName As String) As String
            Return fullName.Substring(_usings.Where(Function(x) fullName.StartsWith(x) AndAlso _
                                                                fullName.Length > x.Length AndAlso _
                                                                fullName(x.Length) = "."c) _
                                         .Select(Function(x) x.Length + 1) _
                                         .DefaultIfEmpty(0) _
                                         .Max())
        End Function
    
        Private Function FindClassInProjectItems(ByVal nprojectItems As ProjectItems, ByVal classname As String) As CodeElement
            If nprojectItems Is Nothing Then Return Nothing
            For Each nprojectitem As ProjectItem In nprojectItems
                Dim found As CodeElement
                If nprojectitem.Kind = EnvDTE.Constants.vsProjectItemKindPhysicalFile Then
                    If nprojectitem.FileCodeModel Is Nothing Then Continue For
                    found = FindClassInCodeElements(nprojectitem.FileCodeModel.CodeElements, classname)
                    If found IsNot Nothing Then Return found
                End If
                If nprojectitem.SubProject IsNot Nothing Then
                    found = FindClassInProjectItems(nprojectitem.SubProject.ProjectItems, classname)
                    If found IsNot Nothing Then Return found
                End If
                found = FindClassInProjectItems(nprojectitem.ProjectItems, classname)
                If found IsNot Nothing Then Return found
            Next
            Return Nothing
        End Function
    
        Private Function FindClassInCodeElements(ByVal elems As CodeElements, ByVal classname As String) As CodeElement
            If elems Is Nothing Then Return Nothing
            For Each elem As CodeElement In elems
                If IsClassType(elem) Then
                    If classname = elem.Name Then Return elem
                ElseIf Not TypeOf elem Is CodeNamespace Then
                    Continue For
                End If
                If _usings.Contains(elem.FullName) Then
                    Dim found As CodeElement = FindClassInCodeElements(GetMembers(elem), classname)
                    If found IsNot Nothing Then Return found
                End If
            Next
            Return Nothing
        End Function
    
        Private Function GetMembers(ByVal elem As CodeElement) As CodeElements
            If TypeOf elem Is CodeClass Then
                Return CType(elem, CodeClass).Members
            ElseIf TypeOf elem Is CodeNamespace Then
                Return CType(elem, CodeNamespace).Members
            ElseIf TypeOf elem Is CodeStruct Then
                Return CType(elem, CodeStruct).Members
            ElseIf TypeOf elem Is CodeInterface Then
                Return CType(elem, CodeInterface).Members
            End If
            Return Nothing
        End Function
    
        Private Function IsClassType(ByVal elem As CodeElement) As Boolean
            Return TypeOf elem Is CodeClass OrElse TypeOf elem Is CodeStruct OrElse TypeOf elem Is CodeInterface
        End Function
    
        Private Function CSharpMemberAssignment(ByVal indent As String, _
                                                ByVal variable As String, _
                                                ByVal membername As String, _
                                                ByVal typeref As EnvDTE.CodeTypeRef) As String
            Dim typekind As EnvDTE.vsCMTypeRef = typeref.TypeKind
            Dim value As String
            If typekind = vsCMTypeRef.vsCMTypeRefArray Then
                value = "{0}{1}.{2} = new {3}[1];"
                Return String.Format(value, indent, variable, membername, TrimKnownNamespace(typeref.ElementType.AsString)) & _
                       ControlChars.NewLine & _
                       CSharpMemberAssignment(indent, variable, membername & "[0]", typeref.ElementType)
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefBool Then
                value = "false"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefChar Then
                value = "'x'"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefDecimal Then
                value = "0.00m"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefDouble Then
                value = "0.00"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefInt Then
                value = "0"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefLong Then
                value = "0"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefShort Then
                value = "0"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefByte Then
                value = "0"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefString Then
                value = """" & membername & """"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefCodeType AndAlso _
                    typeref.AsString = "System.DateTime" Then
                value = String.Format("new DateTime({0:yyyy}, {0:%M}, {0:%d})", DateTime.Today)
            Else
                value = "new " & TrimKnownNamespace(typeref.AsString) & "()"
            End If
            Return String.Format("{0}{1}.{2} = {3};", indent, variable, membername, value)
        End Function
    
        Private Function CSharpMemberGetValue(ByVal indent As String, _
                                              ByVal variable As String, _
                                              ByVal membername As String, _
                                              ByVal typeref As EnvDTE.CodeTypeRef) As String
            Dim typekind As EnvDTE.vsCMTypeRef = typeref.TypeKind
            Dim value As String
            If typekind = vsCMTypeRef.vsCMTypeRefArray Then
                value = "{0}{1}.{2} = new {3}[1];"
                Return String.Format(value, indent, variable, membername, TrimKnownNamespace(typeref.ElementType.AsString)) & _
                       ControlChars.NewLine & _
                       CSharpMemberGetValue(indent, variable, membername & "[0]", typeref.ElementType)
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefBool Then
                value = "src.GetBoolean()"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefChar Then
                value = "src.GetChar()"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefDecimal Then
                value = "src.GetDecimal()"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefDouble Then
                value = "src.GetDouble()"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefInt Then
                value = "src.GetInt32()"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefLong Then
                value = "src.GetInt64()"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefShort Then
                value = "src.GetInt16()"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefByte Then
                value = "src.GetByte()"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefString Then
                value = "src.GetString()"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefCodeType AndAlso _
                    typeref.AsString = "System.DateTime" Then
                value = "src.GetDateTime()"
            Else
                value = "new " & TrimKnownNamespace(typeref.AsString) & "()"
            End If
            Return String.Format("{0}{1}.{2} = {3};", indent, variable, membername, value)
        End Function
    
        Private Function VbMemberAssignment(ByVal indent As String, _
                                            ByVal variable As String, _
                                            ByVal membername As String, _
                                            ByVal typeref As EnvDTE.CodeTypeRef) As String
            Dim typekind As EnvDTE.vsCMTypeRef = typeref.TypeKind
            Dim value As String
            If typekind = vsCMTypeRef.vsCMTypeRefArray Then
                value = "{0}Redim {1}.{2}(1)" ' Vb don't need type argument
                Return String.Format(value, indent, variable, membername, TrimKnownNamespace(typeref.ElementType.AsString)) & _
                       ControlChars.NewLine & _
                       VbMemberAssignment(indent, variable, membername & "(0)", typeref.ElementType)
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefBool Then
                value = "False"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefChar Then
                value = """x""c"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefDecimal Then
                value = "0.00d"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefDouble Then
                value = "0.00r"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefInt Then
                value = "0"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefLong Then
                value = "0L"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefShort Then
                value = "0s"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefByte Then
                value = "0 AS Byte"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefString Then
                value = """" & membername & """"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefArray Then
                value = "New " & TrimKnownNamespace(typeref.ElementType.AsString) & "(1)"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefCodeType AndAlso _
                    typeref.AsString = "Date" Then
                value = String.Format("new Date({0:yyyy}, {0:%M}, {0:%d})", DateTime.Today)
            Else
                value = "new " & TrimKnownNamespace(typeref.AsString) & "()"
            End If
            Return String.Format("{0}{1}.{2} = {3}", indent, variable, membername, value)
        End Function
    
        Private Function VbMemberGetValue(ByVal indent As String, _
                                            ByVal variable As String, _
                                            ByVal membername As String, _
                                            ByVal typeref As EnvDTE.CodeTypeRef) As String
            Dim typekind As EnvDTE.vsCMTypeRef = typeref.TypeKind
            Dim value As String
            If typekind = vsCMTypeRef.vsCMTypeRefArray Then
                value = "{0}Redim {1}.{2}(1)" ' Vb don't need type argument
                Return String.Format(value, indent, variable, membername, TrimKnownNamespace(typeref.ElementType.AsString)) & _
                       ControlChars.NewLine & _
                       VbMemberGetValue(indent, variable, membername & "(0)", typeref.ElementType)
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefBool Then
                value = "src.GetBoolean()"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefChar Then
                value = "src.GetChar()"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefDecimal Then
                value = "src.GetDecimal()"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefDouble Then
                value = "src.GetDouble()"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefInt Then
                value = "src.GetInt32()"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefLong Then
                value = "src.GetInt64()"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefShort Then
                value = "src.GetInt16()"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefByte Then
                value = "src.GetByte()"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefString Then
                value = "src.GetString()"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefArray Then
                value = "New " & TrimKnownNamespace(typeref.ElementType.AsString) & "(1)"
            ElseIf typekind = vsCMTypeRef.vsCMTypeRefCodeType AndAlso _
                    typeref.AsString = "Date" Then
                value = "src.GetDateTime()"
            Else
                value = "new " & TrimKnownNamespace(typeref.AsString) & "()"
            End If
            Return String.Format("{0}{1}.{2} = {3}", indent, variable, membername, value)
        End Function
    End Module
