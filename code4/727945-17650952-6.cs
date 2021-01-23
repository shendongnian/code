    [SqlProcedure] 	
    public static void UserService(string country, stringvatNum) 	
    { 		
        object[] serverResponse = CheckService(country, vatNum);
        // Variables. 		
        SqlMetaData column1Info; 		
        SqlDataRecord record;
        
        // Create the column metadata. 		
        column1Info = new
        SqlMetaData("Column1", SqlDbType.Variant); 		
        
        // Create a new record with the column metadata.       
        record = new SqlDataRecord(new SqlMetaData[]{column1Info});
         
         // Mark the begining of the result-set.
         SqlContext.Pipe.SendResultsStart(record);
         
         foreach (var o in serverResponse) 		
         {
             record.SetValue(0, o);
             SqlContext.Pipe.SendResultsRow(record); 		
         } 		
     
         // Mark the end of  the result-set. 		
         SqlContext.Pipe.SendResultsEnd(); 	
    }
         
    public static object[] CheckService(string country, string vatNum) 	
    {
         bool valid; 		
         string name; 		
         string address; 		
         checkVatService
         vatchecker = new checkVatService(); 	
         vatchecker.checkVat(ref country, ref vatNum, out valid, out name, out address);
         
         return new object[] {country,
                                     vatNum,
                                     valid,
                                     name,
                                     address
                                          }; 
        }
    }
