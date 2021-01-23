    private void updateProgressBar(int percent)
        {
            if (ProgressBar.InvokeRequired)
            {
                updateProgressBarCallback cb = new updateProgressBarCallback(updateProgressBar);
                this.Invoke(cb, new object[] { percent });
            }
            else
            {
                ProgressBar.Value = percent;
                ProgressBar.Update();
                ProgressBar.Refresh();
                ProgressBar.Invalidate();
            }
