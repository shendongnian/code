    private void UpdateBar(int value, int maximum, ProgressBar bar)
    {
        if (bar.InvokeRequired)
        {
            bar.Invoke(new Action<int, int, ProgressBar>(UpdateBar),
                       value, maximum, bar);
        }
        else
        {
            bar.Maximum = maximum;
            bar.Value = value;
            // Insert the percentage
            int percent = value * 100 / maximum;
            bar.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Arial", 8.25f, FontStyle.Regular), Brushes.Black, bar.Width / 2 - 10, bar.Height / 2 - 7);
        }
    }
