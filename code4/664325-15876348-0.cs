    public Form1()
    {
        bgWorker.ProgressChanged += bgWorker_ProgressChanged;
    }
    
    private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        progressBar.Value = e.ProgressPercentage;
        progressBar1.CreateGraphics().DrawString(e.ProgressPercentage.ToString() + "%",
                SystemFonts.DefaultFont, Brushes.Black,
                new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));
    }
