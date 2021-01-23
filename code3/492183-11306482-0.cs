    private void Run() {
         try {
            var work = RequestNewMessage();  // get work
            ProcessWork(work);  // process work
            // Log work 
         }
         catch(Exception ex) {
            // Log Error
         }
         finally {
            // set job for now plus1 minute
            SetRecuringJob(DateTime.UtcNow.AddMinute(1)); 
         }
    }
    private void SetRecuringJob(DateTime dt) {
        PostJob("https://momentapp.com/jobs/new?job[at]={0:s}&job[method]=POST&job[uri]=http://yourapp.com/", dt);
    }
