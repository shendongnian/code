    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        SqlCeConnection con = new SqlCeConnection(@"Data Source=" +
            Directory.GetCurrentDirectory() +
            @"\Database\condrokothadb.sdf;Password=000;");
        if (mood == "bangla")
        {
            SqlCeDataAdapter b = new SqlCeDataAdapter("SELECT english,bangla FROM dic WHERE (bangla like '" + word + "%')", con);
            DataTable tt = new DataTable();
            b.Fill(tt);
        }
        else
        {
            using (con)
            {
                con.Open();
                using (SqlDataAdapter b = new SqlDataAdapter("SELECT english,bangla FROM dic WHERE (english like '" + word + "%')", con))
                {
                    DataTable tt = new DataTable();
                    b.Fill(tt);
                }
            }
        }   
    }
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        dataGridView1.DataSource = tt;
    }
