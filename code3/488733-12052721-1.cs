        Try
            excel = New Microsoft.Office.Interop.Excel.Application()
            wb = excel.Workbooks.Add()
            ws = DirectCast(wb.ActiveSheet, Microsoft.Office.Interop.Excel.Worksheet)
            For Idx As Integer = 0 To dt.Columns.Count - 1
                ws.Range("A1").Offset(0, Idx).Value = dt.Columns(Idx).ColumnName
            Next
            For Idx As Integer = 0 To dt.Rows.Count - 1
                ' <small>hey! I did not invent this line of code, 
                ' I found it somewhere on CodeProject.</small> 
                ' <small>It works to add the whole row at once, pretty cool huh?</small>
                ' YES IT'S COOL Brother ...
                ws.Range("A2").Offset(Idx).Resize(1, dt.Columns.Count).Value = dt.Rows(Idx).ItemArray
            Next
            excel.Visible = True
            wb.Activate()
        Catch ex As Exception
            MessageBox.Show("Error accessing Excel: " & ex.ToString())
        End Try
    End Sub
