    Private Function ImportWorksFile() As Integer
        Dim EndofSheet As Boolean
        Dim BlankRowCounter As Integer
        Dim rr As RowResult
        Dim SecCount As Integer = 0
        Dim SecRow As SecurityRow
        Dim uf As New UtilFunctions
        'If this has already been run, the instance of the excel object would have been 'killed' and needs to be reinstantiated
        If blnExcelProcessKilled Then 'Global boolean var
            xlApp = New Excel.Application()
            blnExcelProcessKilled = False
        End If
        Dim excelProcess(0) As Process
        excelProcess = Process.GetProcessesByName("excel")
        
        Dim tmp As Excel.Workbooks
        Try
            tmp = xlApp.Workbooks
            xlWorkBook = tmp.Open(WorkingFileName)
        Catch ex As Exception
            MessageBox.Show("There was a problem opening the workbook - please try again", CurAFLApp.AppName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return 0
        End Try
        Using dc As New AFLData(CurAFLApp, True)
            Dim cmd As SqlCommand = DefineCommand()
            cmd.CommandType = CommandType.StoredProcedure
            For Each ws As Excel.Worksheet In xlWorkBook.Worksheets
                Dim row As Integer = 1
                EndofSheet = False
                BlankRowCounter = 0
                If ImpCols.ContainsKey(ws.Name) Then
                    SecRow = New SecurityRow(ImpCols(ws.Name))
                    Do Until EndofSheet
                        Try
                            SecRow.NewRow(ws.Rows(row))
                            rr = SecRow.IsValidRow
                            If rr = RowResult.Valid Then
                                ' read this row and process
                                With cmd
                                    .Parameters("@AcctDate").Value = FileDate
                                    .Parameters("@NewSub").Value = SecRow.GetStrCell("newsub")
                                    RunProcedure(cmd)
                                End With
                                SecCount += 1
                                BlankRowCounter = 0
                            Else
                                BlankRowCounter += rr
                            End If
                        Catch ex As Exception
                            MessageBox.Show("There was a problem with row: " & row & " in workbook " & ws.Name)
                        End Try
                        ' if we've counted 50 blank A column values in a row, we're done.
                        If BlankRowCounter <= -50 Then
                            EndofSheet = True
                        End If
                        row += 1
                    Loop
                End If
            Next
        End Using
        Try
            xlWorkBook.Close(SaveChanges:=False)
            xlApp.Workbooks.Close()
            xlApp.Quit()
            '// And now kill the process. C# Version (for reference)
            'if (processID != 0)
            '{
            '    Process process = Process.GetProcessById(processID);
            '    process.Kill();
            '}
            ' Reversed the order of release per  http://stackoverflow.com/questions/12916137/best-way-to-release-excel-interop-com-object
        Catch ex As Exception
            MessageBox.Show("There was a problem CLOSING the workbook - Please double check that the data was imported correctly. ", CurAFLApp.AppName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return 0
        Finally
            releaseObject(tmp)
            releaseObject(xlWorkBook)
            releaseObject(xlApp)
            If Not excelProcess(0).CloseMainWindow() Then
                excelProcess(0).Kill()
                blnExcelProcessKilled = True
            End If
        End Try
        Return SecCount
    End Function
    Public Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
            'Not sure if the following line helps or hinders -- seems to lock things up once in a while
            'GC.WaitForPendingFinalizers()
        End Try
    End Sub
