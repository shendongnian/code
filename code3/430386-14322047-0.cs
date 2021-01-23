    Option Strict Off
    Option Explicit Off
    Imports System
    Imports EnvDTE
    Imports EnvDTE80
    Imports EnvDTE90
    Imports EnvDTE90a
    Imports EnvDTE100
    Imports System.Diagnostics
    
    Public Module RecordingModule
        Sub TemporaryMacro()
            Dim dictionary As New Collections.Generic.Dictionary(Of String, String)
            dictionary.Add("bool", "Boolean")
            dictionary.Add("byte", "Byte")
            dictionary.Add("sbyte", "SByte")
            dictionary.Add("char", "Char")
            dictionary.Add("decimal", "Decimal")
            dictionary.Add("double", "Double")
            dictionary.Add("float", "Float")
            dictionary.Add("int", "Int32")
            dictionary.Add("uint", "UInt32")
            dictionary.Add("long", "Int64")
            dictionary.Add("ulong", "UInt64")
            dictionary.Add("object", "Object")
            dictionary.Add("short", "Int16")
            dictionary.Add("ushort", "UInt16")
            dictionary.Add("string", "String")
            For Each key In dictionary.Keys
                DTE.Find.FindWhat = key
                DTE.Find.ReplaceWith = dictionary(key)
                DTE.Find.Target = vsFindTarget.vsFindTargetCurrentDocument
                DTE.Find.MatchCase = True
                DTE.Find.MatchWholeWord = True
                DTE.Find.MatchInHiddenText = False
                DTE.Find.PatternSyntax = vsFindPatternSyntax.vsFindPatternSyntaxLiteral
                DTE.Find.ResultsLocation = vsFindResultsLocation.vsFindResultsNone
                DTE.Find.Action = vsFindAction.vsFindActionReplaceAll
                DTE.Find.Execute()
            Next
        End Sub
    End Module
