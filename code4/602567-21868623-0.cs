        private int _clicks = 0;
        private void DoWhateverOnDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left)return; // We want left clicks only
            if (++_clicks == 2) 
                DoWhatever(); // if double click then do whatever
            Task.Run(() =>
            {
                Thread.Sleep(300);
                _clicks = 0;
            }); // Reset clicks after 300 ms
        }
