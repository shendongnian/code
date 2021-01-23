        private bool _incomplete;
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_incomplete)
            {
                e.Cancel = true;
            }
        }
