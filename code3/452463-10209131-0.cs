        protected override void InitializeCulture()
        {
        base.InitializeCulture(); 
       
         System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat.NumberDecimalSeparator = ",";    
         System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat.NumberGroupSeparator = ".";                    
        }
