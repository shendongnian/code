    try
    {
      SPList list = null;
      using (SPSite site = new SPSite("http://yoursite/"))
      {
         using (SPWeb web = site.RootWeb)
         {
          //List Will be Created Based on this ListDefinition
    - OOB Custom List Definition
          //00BFEA71-DE22-43B2-A848-C05709900100
    
            foreach (SPList _list in web.Lists)
            {
              if (_list.Title.Equals("TestList"))
              {
                  list = _list;
              }
            }
    
            if (list == null)
            {
             web.AllowUnsafeUpdates = true;
             Guid listID = web.Lists.Add("TestList", //List Title
                          "This is Test List",      //List Description
                          "Lists/TestList",         //List Url
                          "00BFEA71-DE22-43B2-A848-C05709900100", //Feature Id of List definition Provisioning Feature – CustomList Feature Id
                           10778,                     //List Template Type
                         "101");      //Document Template Type .. 101 is for None
    
               web.Update();
               web.AllowUnsafeUpdates = false;
    
             }
            }
    
    
         }
        }
        catch (Exception ex)
        {
    
        }
