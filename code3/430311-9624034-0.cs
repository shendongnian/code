      public class BasePage : PhoneApplicationPage
        {
           protected override OnNavigatedTo(....)
        {
            //some logic that should happen on all your pages (logging to console, etc.)
        }
        }
        
        public class DetailsPage : BasePage
        {
          protected override OnNavigatedTo(....)
        {
        base.OnNavigatedTo(); //the basepage logging, etc.
            //custom page logic (setup VM, querystring parameters, etc.)
        }
    
    }
