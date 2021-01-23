    private void PeerReview()
    {    
        string connStringName = SomethingExternal.GetConnectionString();
        
        using(var connection = new MySqlConnection(connStringName))
        using(var cmd = connection.CreateCommand())
        {
            cmd.CommandText =
                "select name from peer_review_info where active_status=1";
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
       }
    }
