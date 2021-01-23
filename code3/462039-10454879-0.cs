    <script language="C#" runat="server">
    
    void Page_Load(object sender,EventArgs e)
    {
        string conString = WebConfigurationManager.ConnectionStrings["cheese"].ConnectionString;
        using (OdbcConnection con = new OdbcConnection(conString)) {
        con.Open();
        using (OdbcCommand com = new OdbcCommand("SELECT pies FROM ducks WHERE isapie = nope", con)) {
             com.Parameters.AddWithValue("@var", paramWord);
             using (OdbcDataReader reader = com.ExecuteReader()) {
              while (reader.Read()) 
                 Response.Write(reader.GetString(0));
             }//end using reader
         }//end using ODBCCommand
      }//end using ODBCConnection
    }//page_load
    </script>
