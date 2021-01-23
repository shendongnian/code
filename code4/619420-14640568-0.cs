    //need to add  System.Timers in usings
    using System.Timers;
    
    //inside you code
    //create timer with interval 2 sec
    Timer timer=new Timer(2000);
    //add eventhandler 
    timer.Elapsed+=new ElapsedEventHandler(timer_Elapsed);
    //start timer
    timer.Start();
    private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            MessageBox.Show("324");
            //or other actions
        }
