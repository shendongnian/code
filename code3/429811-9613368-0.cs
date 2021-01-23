        ''' <summary>Executes a SqlCommand on the Main DB Connection. Usage: Dim ds As DataSet = ExecuteCMD(CMD) </summary>'
        ''' <param name="CMD">The command type will be determined based upon whether or not the commandText has a space in it. If it has a space, it is a Text command ("select ... from .."), '
        ''' otherwise if there's just one token, it's a stored procedure command</param>'
        Function ExecuteCMD(ByRef CMD As SqlCommand) As DataSet
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("main").ConnectionString
            Dim ds As New DataSet()
            Try
                Dim connection As New SqlConnection(connectionString)
                CMD.Connection = connection
                'Assume that it's a stored procedure command type if there is no space in the command text. Example: "sp_Select_Customer" vs. "select * from Customers"
                If CMD.CommandText.Contains(" ") Then
                    CMD.CommandType = CommandType.Text
                Else
                    CMD.CommandType = CommandType.StoredProcedure
                End If
                Dim adapter As New SqlDataAdapter(CMD)
                adapter.SelectCommand.CommandTimeout = 300
                'fill the dataset'
                adapter.Fill(ds)
                connection.Close()
            Catch ex As Exception
                ' The connection failed. Display an error message.'
                Throw New Exception("Database Error: " & ex.Message)
            End Try
            Return ds
        End Function
