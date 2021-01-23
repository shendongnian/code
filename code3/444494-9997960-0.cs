        private void Form1()
        {
           InitializeComponent();
           if (IsInWinFormsDesignMode())
           {
               // your code stuff here
           }
        }
        public static bool IsInWinFormsDesignMode()
        {
            bool returnValue = false;
 
            #if DEBUG  
            
            if ( System.ComponentModel.LicenseManager.UsageMode == 
                 System.ComponentModel.LicenseUsageMode.Designtime )
            {
                returnValue = true;
            }
            
            #endif
  
            return returnValue;
        }
