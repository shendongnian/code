        SqlCommand cmd;
        SqlDataReader reader;
        SqlConnection con = new SqlConnection("your_database_address");
        DataTable table = new DataTable(); //for data table we have to include namespace System.Data
        cmd = new SqlCommand("SELECT * FROM Fee", con);
        con.Open();
        reader = cmd.ExecuteReader();
        table.Load(reader);
        dataGridView1.DataSource = table;
        reader.Close();
        // table.Clear();
        con.Close();
        dataGridView1.ReadOnly = true;
