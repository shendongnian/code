    namespace MobileViewsInMobileFolder.Utility {
    
        public class MyCustomViewEngine : RazorViewEngine {
    
             public MyCustomViewEngine() {
                 List<string> existingViewLocationFormats = ViewLocationFormats.ToList();
    
                 //Folder Structure: Views\Home\Desktop and Views\Home\Mobile
                 existingViewLocationFormats.Insert(0, "~/Views/{1}/Desktop/{0}.cshtml");
                 existingViewLocationFormats.Insert(0, "~/Views/{1}/Mobile/{0}.cshtml");
    
                 //Folder Structure: Views\Desktop\Home and Views\Mobile\Home
                 existingViewLocationFormats.Insert(0, "~/Views/Desktop/{1}/{0}.cshtml");
                 existingViewLocationFormats.Insert(0, "~/Views/Mobile/{1}/{0}.cshtml");
    
                 ViewLocationFormats = existingViewLocationFormats.ToArray();
             }
        }
    }
