    Public Function FillDataSetFromXML(ByVal Procedure As String, ByVal param As List(Of SqlParameter)) As DataSet
        Dim dbcon As New dbConnection()
        Dim cmd As New SqlCommand()
        Dim ds As New DataSet()
        Dim XR As XmlReader
        XR = Nothing
        Try
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = Procedure
            dbcon.OpenConnection()
            cmd.Connection = dbcon.GetDbConnection()
            If param.Count > 0 Then
                For Each p As SqlParameter In param
                    cmd.Parameters.AddWithValue(p.ParameterName, p.Value)
                Next
            End If
            XR = cmd.ExecuteXmlReader()
            ds.ReadXml(XR)
            Return ds
        Catch ex As Exception
            Return ds
        Finally
            dbcon.CloseConnection()
        End Try
    End Function
    Public Function ExecuteScalar(ByVal Qry As String)
        Dim dbcon As New dbConnection
        Dim cmd As New SqlCommand
        Dim res As String
        Try
            cmd.CommandType = CommandType.Text
            cmd.CommandText = Qry
            dbcon.OpenConnection()
            cmd.Connection = dbcon.GetDbConnection()
            res = cmd.ExecuteScalar().ToString()
            Return res
        Catch ex As Exception
            Return res
        Finally
            dbcon.CloseConnection()
        End Try       
    End Function
    Public Function ExecuteProdedures(ByVal param As List(Of SqlParameter), ByVal Procedure As String) As DataSet
        Dim dbcon As New dbConnection
        Dim ds As New DataSet()
        Try
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = Procedure
            dbcon.OpenConnection()
            cmd.Connection = dbcon.GetDbConnection()
            If param.Count > 0 Then
                For Each p As SqlParameter In param
                    'cmd.Parameters.AddWithValue(p.ParameterName, p.Value)
                    cmd.Parameters.Add(p)
                Next
            End If
            Dim XR As XmlReader
            XR = cmd.ExecuteXmlReader()
            ds.ReadXml(XR)
            Return ds
        Catch ex As Exception
        Finally
            dbcon.CloseConnection()
        End Try
    End Function
