     Dim myWorkBookPath AS String = "C:\test.xlsx"
        Dim mySheetName As String= "Sheet1"
        Dim myRangeAddress as String = "A1:K10"  'if you retrieve this by program, think to remove all $ signs . .Replace("$","")
             Dim myXlConnectionString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0;HDR=YES""", myWorkBookPath)
                  Dim myXlConnection = New OleDb.OleDbConnection(myXlConnectionString)
                  Dim sXlCommand As OleDbCommand = New OleDbCommand(String.Format("Select * FROM [{0}${1}]", mySheetName, myRangeAddress), myXlConnection)
                  Dim dt = New Data.DataTable()
                  Dim da = New OleDbDataAdapter(sXlCommand)
                  myXlConnection.Open()
                  da.Fill(dt)
                  myXlConnection.Close()
                  Return dt
