    try
    {
        using (SqlConnection conn = new SqlConnection(@"Persist Security Info=False;Integrated Security=true;Initial Catalog=myTestDb;server=(local)\SQLEXPRESS;database=Inventory;Data Source=localhost\SQLEXPRESS;"))
        {
            SqlCommand addSite = new SqlCommand(@"INSERT INTO Creation (Name,Product,Quantity,Category) VALUES (@Name,@Product,@Quantity,@Category)", conn);
            addSite.Parameters.AddWithValue("@Name", textBox1.Text);
            addSite.Parameters.AddWithValue("@Product", textBox2.Text);
            addSite.Parameters.AddWithValue("@Quantity", textBox3.Text.ToString());
            addSite.Parameters.AddWithValue("@Category", textBox4.Text);
            thisConnection.Open();
            addSite.ExecuteNonQuery();
        }
    }
    catch
    {
        thisConnection.Close();
    }
