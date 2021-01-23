         //pQ is your query you have created 
         //P4DAL is the key name for connection string 
    
           DataSet ds = pQ.Execute(System.Configuration.ConfigurationManager.ConnectionStrings["Platform4"].ConnectionString);
           
        
          //ds will be used below
          //create your own view model according to what you want in your view 
         //VMData is my view model
        
         var _buildList = new List<VMData>();
                    {
                        foreach (DataRow _row in ds.Tables[0].Rows)
                        {
                            _buildList.Add(new VMData
                            {  
             //chose what you want from the dataset results and assign it your view model fields 
    
                                clientID = Convert.ToInt16(_row[1]),
                                ClientName = _row[3].ToString(),
                                clientPhone = _row[4].ToString(),
                                bcName = _row[8].ToString(),
                                cityName = _row[5].ToString(),
                                provName = _row[6].ToString(),
                            });
        
                           
                          
                        }
        
                    }
    
          //you will use this in your view
          ViewData["MyData"] = _buildList;
        
