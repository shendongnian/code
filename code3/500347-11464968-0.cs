        public static class MyCollectionRepo
        {
        public static void CreateNewCollection(long id, Collection collection) {
                var newCollection = new UserCollection {
                    uid = id,
                    CollectionName = collection.Name,
                    Type = db.CollectionTypes.Where(t => t.CollectionTypeName == collection.Type).First().ctypeid,
                    CreateDate = DateTime.Now
                };
        
                db.UserCollections.AddObject(newCollection);
                db.SaveChanges();
        }
    
     
      }
