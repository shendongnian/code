    List<String> combovalues = new List<String>();
    void bw_cboPlan(object sender, DoWorkEventArgs e)
        {
            SqlConnection con = new SqlConnection(Class.GetConnectionString());
            SqlCommand scProduct = new SqlCommand("spSelectProduct", con);
            scProduct.Parameters.Add(new SqlParameter("@Site",site));
            scProduct.CommandType = CommandType.StoredProcedure;
            SqlDataReader readerPortal;
            con.Open();
            readerPortal = scProduct.ExecuteReader();
            combovalues.Clear();
            while (readerPortal.Read())
            {
                 combovalues.Add(readerPortal[0]); // untested
                //this.Dispatcher.Invoke((Action)delegate(){cboPlan.Items.Add(readerPortal[0]);});
            }
            con.Close();
        }
    
        void bw_cboPlanComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach(var item in combovalues)
                cboPlan.Items.Add(item);
            cboPlan.SelectedIndex = 0;
            Busy.IsBusy = false;
        }
