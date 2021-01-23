           '------Add Columns into your DataTable----------------
            For k As Integer = 0 To CalibSchdNameAry.Length - 1 
                Rectab.Columns.Add(CalibSchdNameAry(k))
            Next
           '-----------------------------------------------------
           '------Add Rows Data Into Your Datatable From Html Table-------
            For i As Integer = 0 To ClbTab.Rows.Count - 1
                Rectab.Rows.Add()
                For j As Integer = 0 To CalibSchdNameAry.Length - 1
                    If i + 1 < ClbTab.Rows.Count - 1 Then
                        Rectab.Rows(i).Item(CalibSchdNameAry(j)) = ClbTab.Rows(i + 1).Cells(j).Text
                    End If
                Next
            Next
