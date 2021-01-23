     private void Form1_Load(object sender, EventArgs e)
     {
        String strConnection = "Data Source=HP\\SQLEXPRESS;database=MK;Integrated Security=true";
        SqlConnection con = new SqlConnection(strConnection);
        try
        {
            con.Open();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = con;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select table_name from information_schema.tables";
            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);
            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            comboBox1.DataSource = dtRecord;
            comboBox1.DisplayMember = "table_name";
            comboBox1.ValueMember = "table_name";
            con.Close();
       }
       catch (Exception ex)
       {
            MessageBox.Show(ex.Message);
       }
    }
