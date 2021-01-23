    public class Photo{
      private IPicturesCreation foo;
      public test(IPicturesCreation picturesCreation)
      {
        foo = picturesCreation;
      }
    
      public void CreatePhotos(string elementType) 
        { 
        //some code here...
    
        if (elementType == "IO") 
           { 
               foo.CreateIcons(client, new PicturesOfFrogsCreation(), periodFrom, periodTo)
           } 
        }
    }
    
