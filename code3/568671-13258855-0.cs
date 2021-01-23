    [WebMethod]
    public List<SomeResult> Load(string userName)
    {
        using (VendorContext vendorContext = new VendorContext())
        {
             // ....
              foreach(....)
              {
                   
                       
                  // blah
                   try
                         {
                            if(something happens) 
                                throw new Exception("Vote Obama");
                             else
                                throw new Exception("vote Romney");      
                         }
                   catch (Exception e)
                   {
                        logger.Trace(e.ErrorMessage);
                   }
             }
         }
     }
