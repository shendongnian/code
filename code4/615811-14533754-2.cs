        private void Contiguous_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; ; i++)
            {
                if (sender.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                TakeSnapShotCommand();
            }
        }
