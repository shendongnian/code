    public class ListRequest
    {
        public string[] Email { get; set; }
        public string FolderAccess { get; set; }
    }
    public List<ListRequest> PreencheValores(SqlDataReader reader)
    {
        var lista = new List<ListRequest>();
        while (reader.Read())
        {
            var listRequest = new ListRequest();   
            if(reader["Email"] != null)   
              listRequest.Email = reader["Email"].ToString().Split(',');
            if(reader["FolderAccess"] != null)
              listRequest.FolderAccess = reader["FolderAccess"].ToString();
            lista.Add(listRequest);
        }
        return lista;
    }
