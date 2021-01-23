    Function GetDataTable(ByVal SQL As String, Optional ByVal ConnectString As String = "", Optional ByVal SingleRow As Boolean = False) As DataTable ' returns read only Datatable
        Try
            If ConnectString.Length = 0 Then ConnectString = g.OISConnectString()
            Using con As New System.Data.SqlClient.SqlConnection(ConnectString)
                Dim rdr As Data.SqlClient.SqlDataReader
                con.Open()
                Dim cmd As New SqlCommand(SQL, con)
                If SingleRow Then
                    rdr = cmd.ExecuteReader(CommandBehavior.SingleRow Or CommandBehavior.CloseConnection)
                Else
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                End If
                Dim dt As New DataTable
                dt.Load(rdr)
                rdr.Close()
                Return dt
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, , "GetDataTable")
            Return Nothing
        End Try
    End Function
    Function GetDataView(ByVal SQL As String, Optional ByVal ConnectString As String = "") As DataView ' returns read only Dataview
        Try
            Dim dt As DataTable
            dt = GetDataTable(SQL, ConnectString)
            If dt.Rows.Count = 0 Then
                Return Nothing
            Else
                Dim dv As New DataView(dt)
                Return dv
            End If
        Catch ex2 As NullReferenceException
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.Message, , "GetDataView")
            Return Nothing
        End Try
    End Function
