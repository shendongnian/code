      Try
    
                If (p_oGrid.RowCount = 0) Then
                    MsgBox("No data", MsgBoxStyle.Information, "App")
                    Exit Sub
                End If
    
                Cursor.Current = Cursors.WaitCursor
    
                Dim sText As New System.Text.StringBuilder
                Dim sTmp As String
                Dim aVisibleData As New List(Of String)
    
                For iAuxRow As Integer = 0 To p_oGrid.Columns.Count - 1
                    If p_oGrid.Columns(iAuxRow).Visible Then
                        aVisibleData.Add(p_oGrid.Columns(iAuxRow).Name)
                        sText.Append(p_oGrid.Columns(iAuxRow).HeaderText.ToUpper)
                        sText.Append(";")
                    End If
                Next
                sText.AppendLine()
    
                For iAuxRow As Integer = 0 To p_oGrid.RowCount - 1
                    Dim oRow As DataGridViewRow = p_oGrid.Rows(iAuxRow)
                    For Each sCol As String In aVisibleData
                        Dim sVal As String
                        sVal = oRow.Cells(sCol).Value.ToString()
                        sText.Append(sVal.Replace(";", ",").Replace(vbCrLf, " ; "))
                        sText.Append(";")
                    Next
                    sText.AppendLine()
                Next
    
                sTmp = IO.Path.GetTempFileName & ".csv"
                IO.File.WriteAllText(sTmp, sText.ToString, System.Text.Encoding.UTF8)
                sText = Nothing
    
                Process.Start(sTmp)
    
            Catch ex As Exception
                process_error(ex)
            Finally
                Cursor.Current = Cursors.Default
            End Try
