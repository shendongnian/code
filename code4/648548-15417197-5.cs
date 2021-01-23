       public IQueryable<ADPerson> FindAll(string UserId)
        {
           // return (from p in db.ADPerson
           //        select p);
            List<ADPerson> lst = new List<ADPerson>();
            var query = from o in db.ADPerson
                        join c in db.MsdnTypes on o.MsdnTypeId equals c.MsdnTypeId
                        select new
                             {
    
                                 AdPersonId = o.AdPersonId,
                                 SamAccountName = o.SamAccountName,
                                 Description = o.Description,
                                 DisplayName = o.DisplayName,
                                 UserPrincipalName = o.UserPrincipalName,
                                 Enabled = o.Enabled,
                                 LastUpdated = o.LastUpdated,
                                 OnlineAssetTag = o.OnlineAssetTag,
                                 MsdnTypeId = o.MsdnTypeId,
                                 MsdnSubscription = c.MsdnTypeDescription
    
                             };
            foreach (var item in query)
            {
                var adPerson = new ADPerson()
                  {
                      AdPersonId = item.AdPersonId,
                      SamAccountName = item.SamAccountName,
                      Description = item.Description,
                      DisplayName = item.DisplayName,
                      UserPrincipalName = item.UserPrincipalName,
                      Enabled = item.Enabled,
                      LastUpdated = item.LastUpdated,
                      OnlineAssetTag = item.OnlineAssetTag,
                      MsdnTypeId = item.MsdnTypeId,
                      MsdnSubscription = item.MsdnSubscription
                  };
                lst.Add(adPerson);
    
            }
    
            return lst.AsQueryable();
                           
                       
            
        }
