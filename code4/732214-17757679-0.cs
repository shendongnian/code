        private void populate()
        {
            listView1.Items.Clear();
            SqlCommand cm;
            if(textBox1.Text == "")
               cm = new SqlCommand("SELECT * FROM lapdev", cn);
            else
                cm = new SqlCommand("SELECT * FROM lapdev WHERE YourField='" + textBox1.Text + "'", cn);
             
    
            try
            {
    
                SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
    
                    ListViewItem it = new ListViewItem(dr["fillingcode"].ToString());
                    it.SubItems.Add(dr["username"].ToString());
                    it.SubItems.Add(dr["branch"].ToString());
                    it.SubItems.Add(dr["department"].ToString());
                    it.SubItems.Add(dr["agency"].ToString());
                    it.SubItems.Add(dr["computername"].ToString());
                    it.SubItems.Add(dr["lapmodel"].ToString());
                    it.SubItems.Add(dr["lapserial"].ToString());
                    it.SubItems.Add(dr["assetnumber"].ToString());
                    it.SubItems.Add(dr["os"].ToString());
                    it.SubItems.Add(dr["winlicense"].ToString());
                    it.SubItems.Add(dr["office"].ToString());
                    it.SubItems.Add(dr["officelicense"].ToString());
                    it.SubItems.Add(dr["hddsize"].ToString());
                    it.SubItems.Add(dr["processor"].ToString());
                    it.SubItems.Add(dr["ram"].ToString());
                    it.SubItems.Add(dr["macadress"].ToString());
                    it.SubItems.Add(dr["ipadress"].ToString());
    
                    listView1.Items.Add(it);
    
                }
    
                dr.Close();
                dr.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
    
        }
