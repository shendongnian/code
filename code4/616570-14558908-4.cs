    public class SSISDetails
    {
        public string PackageData { get; set; }
        public string PackageName { get; set; }
    }
      string storedProc = string.Empty;
            List<SSISDetails> _pkgcol = new List<SSISDetails>();
            string connectionString = "server=localhost;Integrated Security=SSPI";
            using (var conn = new SqlConnection(connectionString))
            using (var command = new SqlCommand("SSISDetails", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                
                    while (reader.Read ())
                    {
                        _pkgcol.Add(new SSISDetails() 
                        {
                           //Please don't write the code like the one below accessing 
                           //columns  using index .
                            PackageName =reader[2].ToString (),
                            PackageData =reader[10].ToString ()
                        });
                       
                    }
                
                conn.Close();
            }
            foreach (var item in _pkgcol.Where (a=>a.PackageName =="YourPackageName") )
            {
                //read the item.PackageData and using Linq to xml retrieve the nodes which
                //you want
            }
