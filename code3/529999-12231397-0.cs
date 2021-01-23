    Stopwatch timer = new Stopwatch();
    timer.Start();
    
    if (((mainRibbonForm)Parent.Parent.Parent.Parent.Parent.Parent.Parent)).myParentScopeVar == false)
    {
       //something goes here   
    }
    
    timer.Stop();  
    TimeSpan timespan = stopWatch.Elapsed;
    
    MessageBox.Show(String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10));    
    timer.Restart();
    if (myLocalScopeVar == false)
    {
         //something goes here
    }
    timer.Stop();  
    TimeSpan timespan = stopWatch.Elapsed;
    MessageBox.Show(String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10)); 
