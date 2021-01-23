        Dim sSheetName As String
        Dim sConnection As String
        Dim dtTablesList As DataTable
        Dim oleExcelCommand As OleDbCommand
        Dim oleExcelReader As OleDbDataReader
        Dim oleExcelConnection As OleDbConnection
        sConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Test.xls;Extended Properties=""Excel 12.0;HDR=No;IMEX=1"""
        oleExcelConnection = New OleDbConnection(sConnection)
        oleExcelConnection.Open()
        dtTablesList = oleExcelConnection.GetSchema("Tables")
        If dtTablesList.Rows.Count > 0 Then
            sSheetName = dtTablesList.Rows(0)("TABLE_NAME").ToString
        End If
        dtTablesList.Clear()
        dtTablesList.Dispose()
        If sSheetName <> "" Then
            oleExcelCommand = oleExcelConnection.CreateCommand()
            oleExcelCommand.CommandText = "Select * From [" & sSheetName & "]"
            oleExcelCommand.CommandType = CommandType.Text
            oleExcelReader = oleExcelCommand.ExecuteReader
            nOutputRow = 0
            While oleExcelReader.Read
            End While
            oleExcelReader.Close()
        End If
        oleExcelConnection.Close()
