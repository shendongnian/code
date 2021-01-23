     public static PhoneApplicationPage GetActivePage(this Application application) {
         PhoneApplicationPage content = null;
         if (application != null) {
             PhoneApplicationFrame rootVisual = application.RootVisual as PhoneApplicationFrame;
             if (rootVisual != null) {
                 content = rootVisual.Content as PhoneApplicationPage;
             }
         }
         return content;
     }
