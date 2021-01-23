      Dim dt As New DataTable
      Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("Blueprint").ToString())
      Dim cmd As New SqlCommand
      cmd.CommandType = CommandType.StoredProcedure
      cmd.CommandText = "spNameHere"
      cmd.Connection = conn
      Using da As New SqlDataAdapter(cmd)
         conn.Open()
         da.Fill(dt)
         conn.Close()
      End Using
