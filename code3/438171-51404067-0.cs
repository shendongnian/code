            Dim Conn As SqlConnection
            Dim Comm As SqlCommand
            Dim Read As SqlDataReader
            Conn = New SqlConnection()
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings("Read").ConnectionString
            Comm = New SqlCommand()
            Comm.CommandType = CommandType.Text
            Comm.CommandText = "SELECT * FROM TABLE"
            Comm.Connection = Conn
            Comm.Connection.Open()
            Read = Comm.ExecuteReader()
            ddlSample.Items.Insert(0, New ListItem("Seleziona", ""))
            While Read.Read()
                ddlSample.Items.Insert(1, New ListItem(Read("ID") & " - " & Read("Desc")), ReadLivelli("ID")))
            End While
            Read.Close()
            Comm.Connection.Close()
            Comm.Dispose()
            Conn.Dispose()
