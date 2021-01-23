    int spam = 0;
    Timer timer = new Timer(2000);
    timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
    timer.Enabled = true;
    
    static void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        spam = 0;
    }
    
    if (spam < 5)
    {
        //send message as usual
        spam++;
    }
    else
        //notify user that sending messages has been disabled, please wait 'x' seconds to send another message
