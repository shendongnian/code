    Public Shared Function GetRecords(ByRef CNobj As System.Data.SqlClient.SqlConnection,
                                       ByRef RSobj As System.Data.DataSet,
                                       ByVal SQLquery As String,
                                       ByVal TableName() As String,
                                       Optional ByVal PrimKeys() As String = Nothing,
                                       Optional ByRef adapter As SqlDataAdapter = Nothing) As Integer
        On Error Resume Next
        Dim DataOkay As Integer = 0                             '[Set to negative if data bad]
        Dim suppliersAdapter As SqlDataAdapter = New SqlDataAdapter()
        'Create connection object, won't create if already exists
        If ConnectToDB(CNobj, False) = False Then
            'error creating object, Session("ErrorMsg") set by called code
            Return -1
        End If
        ' Open the connection.
        If CNobj.State = ConnectionState.Closed Then
            CNobj.Open()
        End If
        ' Create a SqlCommand to retrieve Suppliers data.
        Dim suppliersCommand As SqlCommand = New SqlCommand(SQLquery, CNobj)
        suppliersCommand.CommandType = CommandType.Text
        ' Set the SqlDataAdapter's SelectCommand.
        suppliersAdapter.SelectCommand = suppliersCommand
        ' Fill the DataSet.
        RSobj = New DataSet()
        suppliersAdapter.Fill(RSobj)
        If (Err.Number <> 0) Then
            DataOkay = -1
            _contexts.Session("ErrorMsg") = "Error reading records: " +
                DelDoubleQuotesInString(Err.Description)
            Call Err.Clear()
        ElseIf (RSobj.Tables.Count = 0) Then
            DataOkay = -2
            _contexts.Session("ErrorMsg") = "No tables read reading records for sql=" + SQLquery
        Else
            ' A table mapping names the DataTables.
            Dim IDX As Integer
            For IDX = 0 To TableName.Count - 1
                RSobj.Tables(IDX).TableName = TableName(IDX)
                If PrimKeys IsNot Nothing Then
                    Dim primstr = PrimKeys(IDX)
                    Dim primarr = Split(primstr, ",")
                    Dim primcol(primarr.Count) As DataColumn
                    Dim pidx As Integer
                    For pidx = 0 To primarr.Count
                        primcol(pidx) = RSobj.Tables(IDX).Columns.Item(primarr(pidx))
                    Next
                    RSobj.Tables(IDX).PrimaryKey = primcol
                End If
            Next
            adapter = suppliersAdapter
        End If
        Return DataOkay
    End Function
     Public Shared Function UpdateDB(ByRef dset As System.Data.DataSet, ByVal adapter As SqlDataAdapter)
        If dset.HasChanges = False Then
            Return True
        End If
        ' has multiple tables, select's separated by ;
        Dim SelectQry As String = adapter.SelectCommand.CommandText
        Dim commands() As String = Split(SelectQry, ";")
        Dim idx As Integer = 0
        For Each Table As System.Data.DataTable In dset.Tables
            'Connection object is global in shared ASP.NET module
            If CNobj.State = ConnectionState.Closed Then
                CNobj.Open()
            End If
            'Change select for table being updated.
            adapter.SelectCommand.CommandText = commands(idx)
            'Table.AcceptChanges() 'This prevents update!
            Dim cb As SqlCommandBuilder
            cb = New SqlCommandBuilder(adapter)
            adapter.InsertCommand = cb.GetInsertCommand(True)
            adapter.UpdateCommand = cb.GetUpdateCommand(True)
            adapter.DeleteCommand = cb.GetDeleteCommand(True)
            Try
                adapter.AcceptChangesDuringUpdate = True
                adapter.Update(dset, Table.TableName)
            Catch
                _contexts.Session("ErrorMsg") = "Error saving data to DB: " + Err.Description
                adapter.SelectCommand.CommandText = SelectQry
                Return False
            End Try
            idx += 1
            cb.Dispose()
        Next
        'Put original select back for next call
        adapter.SelectCommand.CommandText = SelectQry
        Return True
    End Function
