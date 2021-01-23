        private void _timer_Elapsed(object sender, ElapsedEventArgs e)  
        {  
            _timer.Stop();  
            Application.Current.Dispatcher.Invoke(new Action(
            () => {
                MessageBox msg = new MessageBox();  
                msg.ShowDialog();  
            }));
            _timer.Start();  
        }  
