      private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=pbs-server;database=p2p;user id=shekar;password=sekhar@1346");
            SqlCommand cmd = new SqlCommand("select states from Country", con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            con.Open();
            da.Fill(ds, "Country");
            cmbStates.DataSource = ds.Tables[0];
            cmbStates.SelectedValue = 0;
            con.Close();
            
        }
        private void cmbStates_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=xxxx;database=xxxx;user id=xxxxr;password=xxxxxx");
            SqlCommand cmd = new SqlCommand("select cities from States where cityname = 'cmbStates.SelectedItem.ToString()'", con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            con.Open();
            da.Fill(ds, "States");
            cmbCities.DataSource = ds.Tables[0];
            cmbCities.SelectedValue = 0;
            con.Close();           
            
        }
