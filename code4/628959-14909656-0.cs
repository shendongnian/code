      public bool insert(string q)
      {   
         bool result=false;
         SqlCommand cmd = new SqlCommand(q,con);
           try
            {       
              con.Open();
              cmd.ExecuteNonQuery();
              con.Close();
              result=true
            }
           catch { };
           return result; 
          }
