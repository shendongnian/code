     using (SqlConnection CONN = new SqlConnection("server=?;database=?;Integrated Security=?"))  {
          
     Dim queryString As String = "SELECT CustomerID, CompanyName FROM dbo.Customers"
     Dim adapter As SqlDataAdapter = New SqlDataAdapter(queryString, connection)
     Dim dset As DataSet = New DataSet 
     adapter.Fill(dset, "Customers")
     List<string> lst = new List<string>();
     //iterate through Dataset
     foreach(DataRow row in dset.Tables["Customers"].Rows)
     {
       lst.Add(row["CompanyName"].ToString());
     }
     //to string array
     string[] str = lst.ToArray();
}
