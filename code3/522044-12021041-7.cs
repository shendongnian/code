    public ActionResult FBLandingPageFinal (string accessToken)
        {
         var newfb = new FacebookClient (accessToken);
         dynamic jsonResult= newfb.Get ( 
                                 "fql", 
                                  new { 
                                   q = "select uid, name from user where is_app_user = 1 and uid in (SELECT uid2 FROM friend WHERE uid1 = me())" 
                                      });
         var serializer = new JavaScriptSerializer();
         ViewBag.FQLResultSet = serializer.Deserialize<ImageSet>(jsonResult);
        }
    // You have to define this class
    public class FbImage
    {
       public string string name {get; set;}
       public string string uid {get; set;}
    }
    // And this one
    public class ImageSet
    {
       public List<FbImage> images {get; set;}
    }
   
