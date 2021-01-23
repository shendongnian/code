    void  myTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e) 
    {
        if (DateTime.Now.Hour >= 23)
            this.Invoke((Action)delegate() { Close(); });
    }
