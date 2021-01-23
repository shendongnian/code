    ''' <summary>
    ''' ReadToDataTable reads the given Excel file to a datatable.
    ''' </summary>
    ''' <param name="table">The table to be populated.</param>
    ''' <param name="incomingFileName">The file to attempt to read to.</param>
    ''' <returns>TRUE if success, FALSE otherwise.</returns>
    ''' <remarks></remarks>
    Public Function ReadToDataTable(ByRef table As DataTable,
                                    incomingFileName As String) As Boolean
        Dim returnValue As Boolean = False
        Try
            Dim sheetName As String = ""
            Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & incomingFileName & ";Extended Properties=""Excel 12.0;HDR=No;IMEX=1"""
            Dim tablesInFile As DataTable
            Dim oleExcelCommand As OleDbCommand
            Dim oleExcelReader As OleDbDataReader
            Dim oleExcelConnection As OleDbConnection
            oleExcelConnection = New OleDbConnection(connectionString)
            oleExcelConnection.Open()
            tablesInFile = oleExcelConnection.GetSchema("Tables")
            If tablesInFile.Rows.Count > 0 Then
                sheetName = tablesInFile.Rows(0)("TABLE_NAME").ToString
            End If
            If sheetName <> "" Then
                oleExcelCommand = oleExcelConnection.CreateCommand()
                oleExcelCommand.CommandText = "Select * From [" & sheetName & "]"
                oleExcelCommand.CommandType = CommandType.Text
                oleExcelReader = oleExcelCommand.ExecuteReader
                'Determine what row of the Excel file we are on
                Dim currentRowIndex As Integer = 0
                While oleExcelReader.Read
                    'If we are on the First Row, then add the item as Columns in the DataTable
                    If currentRowIndex = 0 Then
                        For currentFieldIndex As Integer = 0 To (oleExcelReader.VisibleFieldCount - 1)
                            Dim currentColumnName As String = oleExcelReader.Item(currentFieldIndex).ToString
                            table.Columns.Add(currentColumnName, GetType(String))
                            table.AcceptChanges()
                        Next
                    End If
                    'If we are on a Row with Data, add the data to the SheetTable
                    If currentRowIndex > 0 Then
                        Dim newRow As DataRow = table.NewRow
                        For currentFieldIndex As Integer = 0 To (oleExcelReader.VisibleFieldCount - 1)
                            Dim currentColumnName As String = table.Columns(currentFieldIndex).ColumnName
                            newRow(currentColumnName) = oleExcelReader.Item(currentFieldIndex)
                            If IsDBNull(newRow(currentFieldIndex)) Then
                                newRow(currentFieldIndex) = ""
                            End If
                        Next
                        table.Rows.Add(newRow)
                        table.AcceptChanges()
                    End If
                    'Increment the CurrentRowIndex
                    currentRowIndex += 1
                End While
                oleExcelReader.Close()
            End If
            oleExcelConnection.Close()
            returnValue = True
        Catch ex As Exception
            'LastError = ex.ToString
            Return False
        End Try
        Return returnValue
    End Function
