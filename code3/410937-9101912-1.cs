        Timer timer = new System.Timers.Timer(5000);//5 seconds
        timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
        private void form_MouseHover(object sender, System.EventArgs e) 
        {            
            timer.Start();
        }
        private void form_MouseLeave(object sender, System.EventArgs e) 
        {            
            timer.Stop();
        }
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer.Stop();
            OpenFileOrFolder();//Edit : implement your file / folder opening logic here
        }
