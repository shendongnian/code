    public List<mahasiswaData> GetData(){
    
        
        List<mahasiswaData> gridData = new List<mahasiswaData>();
    
    
        try{
    
            using(SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DBMahasiswa;Data Source=."))
            {
                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Text = "dbo.SP_GetData";
                 
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
    		            if(reader.HasRows){
                            while(reader.Read())
                            {
                               object rawName = reader.GetValue(reader.GetOrdinal("Name"));
                               object rawAge = reader.GetValue(reader.GetOrdinal("Age"));
                              
                               if(rawName == DBNull.Value || rawAge == DBNull.Value)
                               {
                                   //Use logging to indicate name or age is null and continue onto the next record
                                   continue;
                               }
                               //Use the object intializer syntax to create a mahasiswaData object inline for simplicity
                               gridData.Add(new mahasiswaData()
                                                       {
     						        Nama = Convert.ToString(rawName),
                                                            Umur = Convert.ToInt32(rawAge) 
                                                       });
    
      
                            }
                        }
                        else{
                            //Use logging or similar to record that there are no rows. You may also want to raise an exception if this is important.
                        }
    
                    }
    
                }
    
    
            }
    
    
        }
        catch(Exception e)
        {
           //Use your favourite logging implementation here to record the error. Many projects use log4Net
           throw; //Throw the error - display and explain to the end user or caller that something has gone wrong!
        }
    
    
        return gridData;
    
    
    }
