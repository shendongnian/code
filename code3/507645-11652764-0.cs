    [WebMethod]
            public void addGame()
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(@"C:\Users\bradleya\Documents\Visual Studio 2010\Projects\Web Services\Web Services\addGame.xml");
                XmlNode documentNode = xd.SelectSingleNode("/NewDataSet/Game");
    
                int GamePlayID = Convert.ToInt32(documentNode.SelectSingleNode("GamePlayID").InnerText);
                int ParticipantID = Convert.ToInt32(documentNode.SelectSingleNode("ParticipantID").InnerText);
                int GameVersionID = Convert.ToInt32(documentNode.SelectSingleNode("ParticipantID").InnerText);
                string Start = Convert.ToString(documentNode.SelectSingleNode("Start-Time").InnerText);
                string End = Convert.ToString(documentNode.SelectSingleNode("End-Time").InnerText);
                string success = Convert.ToString(documentNode.SelectSingleNode("Success").InnerText);
    
                SqlConnection oConn = new SqlConnection();
                oConn.ConnectionString = @"Data Source=SNICKERS\SQLEXPRESS;Initial Catalog=VerveDatabase;Integrated Security=True";
                oConn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = oConn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "addGamePlay";
                cmd.Parameters.Add(new SqlParameter("@GamePlayID", SqlDbType.Int));
                cmd.Parameters["@GamePlayID"].Value = GamePlayID;
                cmd.Parameters.Add(new SqlParameter("@ParticipantID", SqlDbType.Int));
                cmd.Parameters["@ParticipantID"].Value = @ParticipantID;
                cmd.Parameters.Add(new SqlParameter("@GameVersionID", SqlDbType.Int));
                cmd.Parameters["@GameVersionID"].Value = @GameVersionID;
                cmd.Parameters.Add(new SqlParameter("@Start", SqlDbType.Time));
                cmd.Parameters["@Start"].Value = Start;
                cmd.Parameters.Add(new SqlParameter("@End", SqlDbType.Time));
                cmd.Parameters["@End"].Value = End;
                cmd.Parameters.Add(new SqlParameter("@success", SqlDbType.VarChar, 10));
                cmd.Parameters["@success"].Value = success;
                cmd.ExecuteNonQuery();
            }
