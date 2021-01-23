    [HttpPost]
    public ActionResult PostedPerson (FormCollection fc)
    {
     for( var val in fc )
     { 
      if( val is InnerList ){
      {
       if( val.Contains("EncryptedTrue") )
       {
        //then val.SSN would be an encryped social security number
       }
      }
     }
    }
