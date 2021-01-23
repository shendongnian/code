    class drawOnDesktop
    {
        public Form dodF = new Form();
        List<Point> circles = new List<Point>();
        public drawOnDesktop()
        {
            dodF.BackColor = Color.LightGreen;
            dodF.TransparencyKey = Color.LightGreen;
            dodF.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            dodF.Location = new Point(0, 0);
            dodF.StartPosition = FormStartPosition.Manual;
            dodF.FormBorderStyle = FormBorderStyle.None;
            dodF.WindowState = FormWindowState.Maximized;
            dodF.MinimizeBox = false;
            dodF.MaximizeBox = false;
            dodF.ControlBox = false;
            dodF.TopMost = true;  //For development in case something goes wrong
            dodF.BringToFront();
            dodF.Paint += dodF_Paint;
            dodF.Show();
        }
        void dodF_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = dodF.CreateGraphics())
            {
                foreach(Point location in circles)
                    g.FillEllipse(Brushes.Black, location.X, location.Y, 10, 10);    
            }
        }
        public  void drawCircle(Point location)
        {
            circles.Add(location);
        }
    }
