    public Form1()
    {
        InitializeComponent();
        var pictureBox = new RotatingPictureBox
        {
            Angle = Math.PI,
            Speed = Math.PI/20,
            Distance = 50,
            BackColor = Color.Black,
            Width = 10,
            Height = 10,
            Location = new Point(100, 50)
        };
        Controls.Add(pictureBox);
        var timer = new Timer();
        timer.Interval = 10;
        timer.Tick += (sender, args) => pictureBox.RotateStep();
        timer.Start();
    }
