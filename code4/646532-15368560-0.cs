     int counter=0;
     while (results.Read())
     {
         if(counter++=0)
         {
              ResultLabel.Text = NewComm.ExecuteScalar().ToString();
              conn.Close();
              break;
         }
     }
