    Stopwatch timer = new Stopwatch();
    timer.Start();
    
    for(int i = 0; i < 1000; i++)
    {
        if (((mainRibbonForm)Parent.Parent.Parent.Parent.Parent.Parent.Parent)).myParentScopeVar == false)
        {
             //something goes here   
        }
    }
    
    timer.Stop();  
    TimeSpan timespan = timer.Elapsed;
    
    MessageBox.Show(String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10));    
    timer.Restart();
    for(int i = 0; i < 1000; i++)
    {
        if (myLocalScopeVar == false)
        {
             //something goes here
        }
    }
    timer.Stop();  
    TimeSpan timespan = timer.Elapsed;
    MessageBox.Show(String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10)); 
