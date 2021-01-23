      private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            Task.Factory.StartNew(Login)
                .ContinueWith(t => 
                    { 
                        progressBar1.Visible = false; 
                    }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        private static void Login()
        {
            // should replace this with actual login stuff
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }
