    Private Function GetNamespace() As String
        Dim classInfo As CodeClass2 = GetClassElement()
        Return classInfo.FullName
    End Function
    Private Function GetClassElement() As CodeClass2
        Try
            Dim selection As TextSelection = DTE.ActiveDocument.Selection
            Dim fileCodeModel As FileCodeModel2 = DTE.ActiveDocument.ProjectItem.FileCodeModel
            Dim element As CodeElement2 = fileCodeModel.CodeElementFromPoint(selection.TopPoint, vsCMElement.vsCMElementClass)
            Return element
        Catch
            Return Nothing
        End Try
    End Function
