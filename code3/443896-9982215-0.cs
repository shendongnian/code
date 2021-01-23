    Action message = () => MessageBox.Show("!!!!!!!!!!!!!"));
    object lockOb = new object();
    
    void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        lock(lockOb)
            if(null != message)
            {
                message();
                message = null;
            }
    }
