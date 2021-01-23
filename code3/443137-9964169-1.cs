    public int executeUID(MySqlCommand msCommand, bool Mode) //Mode==true means insertandRetriveLastID, false means =dont retrive last insertedit
    {
      try
      {
        this.Open();
    
        msCommand.Connection = this.msCon;
    
        if(Mode)  //for getting last inserted id 
       {
          SqlParameter outParams= new SqlParameter("@ID", SqlDbType.Int);
          outParams.Direction =    ParameterDirection.Output;
          msCommand.Parameters.Add(outParams)
          msCommand.ExecuteNonQuery();
          var outputValue = cmd.Parameters["@ID"].Value;  
       }
        else //if no inserted id is not there 
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
