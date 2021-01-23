    List<tblResource> GetResources(long grpid)
    {
         try
         {               
             return dataContext.tblResource.Where(c => grpIDArray.Contains(c.GroupId)
             && c.IsActive == true).ToList();    
         }
         catch (Exception ex)
         {                
              return ex;
         }
     }
