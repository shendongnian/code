    private void PeerReview()
    {    
        MySqlConnection connection;
        string connStringName =
            "server=localhost;database=hourtracking;uid=username;password=password";
        connection = new MySqlConnection(connStringName);
    
        cmd.CommandText = "select name from peer_review_info where active_status=1";
        cmd.Connection = connection;
        connection.Open();
        using (SqlDataReader sdr = cmd.ExecuteReader())
        {
            while (sdr.Read())
            {
                ListItem item = new ListItem();
                item.Text = sdr["peerrevid"].ToString();
                item.Value = sdr["peerrevid"].ToString();
                item.Selected = Convert.ToBoolean(sdr["IsSelected"]);
                chkPeerRev.Items.Add(item);
            }
       }
       connection.Close();
    }
