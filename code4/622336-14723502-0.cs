        private void CreateTimer()
        {
            var t = new Timer();
            t.Interval = 1000; //how often update timer (in ms)
            t.Tick += new EventHandler(Tick);
            t.Start();
        }
        private void Tick(object sender, EventArgs e)
        {
            //logic to update your data grid view.
        }
