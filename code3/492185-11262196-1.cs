    Using Reader As New Microsoft.VisualBasic.FileIO.TextFieldParser("C:\MyFile.csv")
    Reader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
    Dim MyDelimeters(0 To 0) As String
    Reader.HasFieldsEnclosedInQuotes = False
    Reader.SetDelimiters(","c)
    Dim currentRow As String()
    While Not Reader.EndOfData
        Try
            currentRow = Reader.ReadFields()
            Dim currentField As String
            For Each currentField In currentRow
                MsgBox(currentField)
            Next
        Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
            MsgBox("Line " & ex.Message &
            "is not valid and will be skipped.")
        End Try
    End While
    End Using
