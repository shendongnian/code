      Your complete solution
        public void InsertVideo()
          {
             MySqlConnection conn = new  MySqlConnection(ConfigurationManager.ConnectionStrings["AxWaveConnection"].ToString());
             MySqlCommand cmd = new MySqlCommand("InsertVideo", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open()
            cmd.Parameters.Add(new MySqlParameter("in_youtubevideoid", VideoId));
            cmd.Parameters.Add(new MySqlParameter("in_title", Title));
            cmd.Parameters.Add(new MySqlParameter("in_rating", ViewCount));
            cmd.Parameters.Add(new MySqlParameter("in_viewcount", Rating));
            cmd.ExecuteNonQuery();
          }
