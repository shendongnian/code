    namespace TestDays
    {
        [Activity]
        public class MainActivity : Activity
        {
            protected override void OnCreate(Bundle savedInstance) 
            {
                base.OnCreate(savedInstance);
                testDays();
                SetContentView(R.Layouts.MainLayout);
            }
            
            		public enum Days { Sat = 1, Sun, Mon }
    
    		public int testDays() 
    		{
    			Days day = Days.Sun;
    			int dayNumber = (int)day; // <----- Throws Error
    			return dayNumber;
    		}
    
       }
    }
