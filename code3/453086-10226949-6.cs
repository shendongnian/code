    int id = 0;
    TranslationUnit tu = null;
    while (tuReader.Read()) 
    {    
      if(id != tuReader.GetInt64(0))
      {
        id = tuReader.GetInt64(0);
        tu = new TranslationUnit                   
        {                   
         TranslationUnitId = id,                   
         DocumentId = tuReader.GetInt64(1),                   
         Raw = tuReader.GetString(2),                   
         IsSegmented = tuReader.GetBoolean(3),                   
         Reader = this, // Ryan: Fixed so that it sets the reader to itself                   
       };
      }                   
                                      
      tu.Properties.Add(GetProperty(tuReader));                   
    }                   
