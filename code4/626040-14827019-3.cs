     using (SqlConnection CONN = new SqlConnection("server=?;database=?;Integrated Security=?"))  {
          //e.g. new SqlConnection("Data Source=localhost;Integrated Security=SSPI;Initial Catalog=dbname");
     String queryString = "SELECT CustomerID, CompanyName FROM dbo.Customers";
     SqlDataAdapter adapter = New SqlDataAdapter(queryString, CONN);
     DataSet dset = New DataSet(); 
     adapter.Fill(dset, "Customers");
         List<string> lst = new List<string>();
         //iterate through Dataset
         foreach(DataRow row in dset.Tables["Customers"].Rows)
         {
           lst.Add(row["CompanyName"].ToString());
         }
         //to string array
         string[] str = lst.ToArray();
    }
