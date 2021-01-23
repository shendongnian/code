    private void popup()
        {
            Thread th = new Thread(() =>
            {
                try
                {
                    Open();
                }
                catch (Exception)
                {
                    
                }
            });
            th.Start();
            Thread.Sleep(3000);   //you can update this time as your requirement
            th.Abort();
        }
        private void Open()
        {
            Form1 frm = new Form1();
            frm.ShowDialog();   // frm.Show(); if MDI Parent form
        }
