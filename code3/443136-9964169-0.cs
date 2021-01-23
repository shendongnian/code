    public int executeUID(MySqlCommand msCommand, bool Mode) //Mode==true means insertandRetriveLastID, false means =dont retrive last insertedit
    {
      try
      {
        this.Open();
    
        msCommand.Connection = this.msCon;
    
        if(Mode) 
            return int.Parse(msCommand.ExecuteScalar().ToString());
        else 
        {
           return msComand.ExecuteNonQuery(); // it will return No of Rows Affected. 
        }
       
      }
      catch (MySqlException ex)
      {
        throw ex;
      }
      finally
      {
        this.Close();
      }
    }
