    public Form1()
    {
        InitializeComponent();
        var pbe = new ProgressBarEx {Location = new Point(100, 100)};
        this.Controls.Add(pbe);
        for (var i = 0; i < 4; i++)
        {
            var size = i * 10 + 30;
            var partId = pbe.AddPart(size);
            var pb = new ProgressBar
                         {
                             Maximum = size,
                             Location = new Point(100, i * 30 + 130)
                         };
            this.Controls.Add(pb);
            var timer = new Timer {Interval = 1000 + i * 100};
            timer.Tick += (sender, args) =>
                              {
                                  pb.Value += 5;
                                  pbe.AddProgress(partId, 5);
                                  if (pb.Value == pb.Maximum)
                                  {
                                      timer.Stop();
                                  }
                              };
            timer.Start();
        }
    }
