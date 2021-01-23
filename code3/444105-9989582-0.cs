    private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        try{
            // stop the timer while we are running the cleanup task
            _timer.Stop();
            //
            // do cleanup stuff
            //
        }catch (Exception e){
             //do your error handling here.
	    }
	    finally{
				
           _timer.Start();
	    }
         
        }
    }
