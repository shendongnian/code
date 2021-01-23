    somepage.aspx:
    
    public class SomePage : Page
    {
    
        public static void DoSomething()
        {
            ...
        }
    
    }
    
    global.asax:
    
    void Application_Start(object sender, EventArgs e) 
    {
        ...
    
        // Add handler for Elapsed event
        timScheduledTask.Elapsed += new System.Timers.ElapsedEventHandler(timScheduledTask_Elapsed);
    
    
    }
    
    void timScheduledTask_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        SomePage.DoSomething(); 
    }
