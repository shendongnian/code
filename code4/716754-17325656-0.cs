    Public Sub DisplayCharacterCodes()
    
        Dim i As Long
        Dim c As String
    
        Application.ActiveDocument.Paragraphs.Reset
        Application.ActiveDocument.Paragraphs(1).Range.Text = "1" & Chr(11) & "2"
    
        For i = 1 To Application.ActiveDocument.Characters.Count
            c = c & vbCrLf & CStr(Asc(Application.ActiveDocument.Characters(i).Text))
        Next i
    
        MsgBox c
    
    End Sub
