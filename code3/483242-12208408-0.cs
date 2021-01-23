    Imports ICSharpCode.AvalonEdit.Folding
    Imports ICSharpCode.AvalonEdit.Document
    Public Class VBNETFoldingStrategy
        Inherits AbstractFoldingStrategy
        Private foldableKeywords() As String = {"namespace", "class", "sub", "function", "structure", "enum"}
        Public Overrides Function CreateNewFoldings(document As ICSharpCode.AvalonEdit.Document.TextDocument, ByRef firstErrorOffset As Integer) As System.Collections.Generic.IEnumerable(Of ICSharpCode.AvalonEdit.Folding.NewFolding)
            firstErrorOffset = -1
            Dim foldings As New List(Of NewFolding)
            Dim text As String = document.Text
            Dim lowerCaseText As String = text.ToLower()
            For Each foldableKeyword In foldableKeywords
                foldings.AddRange(GetFoldings(text, lowerCaseText, foldableKeyword))
            Next
            Return foldings.OrderBy(Function(f) f.StartOffset)
        End Function
        Public Function GetFoldings(text As String, lowerCaseText As String, keyword As String) As IEnumerable(Of NewFolding)
            Dim foldings As New List(Of NewFolding)
            Dim closingKeyword As String = "end " + keyword
            Dim closingKeywordLength As String = closingKeyword.Length
            keyword += " "
            Dim keywordLength As String = keyword.Length
            Dim startOffsets As New Stack(Of Integer)
            For i As Integer = 0 To text.Length - closingKeywordLength
                If lowerCaseText.Substring(i, keywordLength) = keyword Then
                    Dim k As Integer = i
                    If k <> 0 Then
                        Dim lastLetterPos As Integer = i
                        Do Until text(k - 1) = vbLf OrElse text(k - 1) = vbCr
                            If Char.IsLetter(text(k)) Then lastLetterPos = k
                            k -= 1
                        Loop
                        If lastLetterPos > k Then k = lastLetterPos
                    End If
                    startOffsets.Push(k)
                ElseIf lowerCaseText.Substring(i, closingKeywordLength) = closingKeyword Then
                    Dim startOffset As Integer = startOffsets.Pop()
                    Dim newFolding As NewFolding = New NewFolding(startOffset, i + closingKeywordLength)
                    Dim p As Integer = text.IndexOf(vbLf, startOffset)
                    If p = -1 Then p = text.IndexOf(vbCr, startOffset)
                    If p = -1 Then p = text.Length - 1
                    newFolding.Name = text.Substring(startOffset, p - startOffset)
                    foldings.Add(newFolding)
                End If
            Next
            Return foldings
        End Function
    End Class
