    public Form1()
            {
                InitializeComponent();
                Rectangle r = Screen.PrimaryScreen.WorkingArea;
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(0, Screen.PrimaryScreen.Bounds.Height - this.Height);
            }
