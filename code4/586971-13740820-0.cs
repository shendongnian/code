    Task.Factory.StartNew(() => Thread.Sleep(30 * 1000))
                .ContinueWith((t) =>
        {
             viewport.Visible = false;
             viewport2.Visible = true;
             pictureBox1.Visible = true;
             start_Webc(); 
             video2.Play();
        }, TaskScheduler.FromCurrentSynchronizationContext());
