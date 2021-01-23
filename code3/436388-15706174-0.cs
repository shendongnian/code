    // if i were to visualizeyour lib.dll data initializer call like this:
    class BaseUserControl
    {
        // i'm guessing that you initialize the data somehow... 
        void InitializeData()
        {
            if (!DesignMode)
            {
                InitializeDataLocal();
            }
        }
        
        protected virtual InitializeDataLocal()
        {
            // whatever base behavior you want should go here.
        }
    }
    // in the derived classes, just put the code you currently have for 
    // fetching the data from lib.dll here...
    class UserControl : BaseUserControl
    {
        protected override InitializeDataLocal()
        {
            // fetch from lib.dll...
          
            // optionally invoke some base behavior as well, 
            // if you need to...
            base.InitializeDataLocal();
        }
    }
