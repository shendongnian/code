    namespace Layer2
    {
        public class Worker
        {
            IApplicationContext _context;
            public void DoJob(IApplicationContext context)
            {
                _context = context;
                _context.SetTimeout(JobTimedOut,3000);
                // nothing ... (wait for other devices or user events)
            }
    
            void JobTimedOut()
            {
                // do something suitable for timeout error with _context or anything else
            }
    
        }
    }  
