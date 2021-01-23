    public class PhotoAccess
    {
    
      public class PhotoInfo
      {
        public int PhotoID {get; set;}
        public string FileName {get; set;}
      }
      
      public IEnumerable<PhotoInfo> GetPhotos()
      {
       using ( var dbCon = new lnqPhotoDataContext())
       {
          var res = from p in dbCon.Photos 
                orderby p.PhotoID descending 
                select new PhotoInfo 
                           {
                              p.PhotoID, 
                              p.FileName 
                           };
          return res.AsEnumerable();
        }
      }
      public bool UpdateSave(...)
      {
          ... code to do update or save, use here only classes for working with the DB
      }
    }
