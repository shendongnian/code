        SqlConnection con;
        DataTable dt1;
        SqlDataAdapter da;
        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();
            con.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\dbTestCSV.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            con.Open();
            string sql = "SELECT * FROM tblTestCSV";
            da = new SqlDataAdapter(sql, con);
            SqlCommandBuilder cb;
            cb = new SqlCommandBuilder(da);
            dt1 = ParseCSV("C:\\testcsv3.csv");
            
            dt1.Columns[0].ColumnName = "Numbers";
            dt1.Columns[1].ColumnName = "Col1";
            dt1.Columns[2].ColumnName = "Col2";
            dt1.Columns[3].ColumnName = "Col3";
            dt1.Columns[4].ColumnName = "Col4";
            dt1.Columns[5].ColumnName = "Col5";
            DataSet ds2 = new DataSet();
            da.Fill(ds2);
            // THIS IS THE KEY BIT!! This adds the rows from the datatable to the dataset one by one.
            // I guess the "Update" command in the dataadapter needs this to happen, rather than just 
            // adding the table "dt1" to the dataset all at once. Can anyone explain why?
            foreach (DataRow dRow in dt1.Rows)
            {
                DataRow dsRow = ds2.Tables["Table"].NewRow();
                dsRow.ItemArray = dRow.ItemArray;
                ds2.Tables["Table"].Rows.Add(dsRow);
            }
            da.Update(ds2,"Table");
            dataGridView1.DataSource = dt1;
            con.Close();
            da.Dispose();
        }
