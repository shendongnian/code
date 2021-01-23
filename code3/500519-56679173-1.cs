     SqlConnection con = new SqlConnection("Data Source=.\SQLEXPRESS;Initial Catalog=databasename;User ID=sa;Password=123");
     con.Open();
     SqlCommand cmd = new SqlCommand("SELECT TOP(1) UID FROM InvoiceDetails ORDER BY 1 DESC", con);
     SqlDataReader reader = cmd.ExecuteReader();
     //won't need a while since it will only retrieve one row
     while (reader.Read())
     {
         string data = reader["UID"].ToString();
         //txtuniqueno.Text = data;
         //here is your data
         //cal();
         //txtuniqueno.Text = data.ToString();
         int i = Int32.Parse(data);
         i++;
         txtuid.Text = i.ToString();
      }
