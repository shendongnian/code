        public partial class LowerRightForm : Form
        {
            public LowerRightForm()
            {
                InitializeComponent();
            }
            protected override void OnLoad(EventArgs e)
            {
                PlaceLowerRight();
                base.OnLoad(e);
            }
            private void PlaceLowerRight()
            {
                //Determine "rightmost" screen
                Screen rightmost = Screen.AllScreens[0];
                foreach (Screen screen in Screen.AllScreens)
                {
                    if (screen.WorkingArea.Right > rightmost.WorkingArea.Right)
                        rightmost = screen;
                }
                this.Left = rightmost.WorkingArea.Right - this.Width;
                this.Top = rightmost.WorkingArea.Bottom - this.Height;
            }
        }
