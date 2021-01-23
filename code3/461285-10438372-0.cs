      FbConnection fbCon = new FbConnection(csb.ToString());
      FbCommand fbCom = new FbCommand("INSERT INTO players(ID,name,score) VALUES (@id,@name,@score)", fbCon);
      fbCom.Parameters.AddWithValue("id", zID + 1);
      fbCom.Parameters.AddWithValue("name", var);
      fbCom.Parameters.AddWithValue("score", score);
      fbCom.ExecuteNonQuery();
