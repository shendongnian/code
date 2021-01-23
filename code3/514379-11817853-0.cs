    Dictionary<int, ProgressBar> progressBars = new Dictionary<int, ProgressBar>();
    
    for(int i = 0; i < someValue; i++) {
    ProgressBar progressBar = new ProgressBar();
    progressBar.Size = new System.Drawing.Size(516, 23);
    progressBar.Location = new Point(10, 36);
    groupBox4.Controls.Add(progressBar);
    progressBars.Add(i, progressBar);
    }
