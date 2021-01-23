        public MainWindow()
        {
            
            InitializeComponent();
            for (int j = 0; j < 112; j++)
            {
                for (int i = 0; i < 116; i++)
                {
                    ellipse = new Ellipse();
                    ellipse.Name = "EllipseX" + i.ToString() + "Y" + j.ToString();
                    ellipse.StrokeThickness = 1;
                    ellipse.Stroke = System.Windows.Media.Brushes.Blue;
                    ellipse.Width = 5;
                    ellipse.Height = 5;
                    ellipse.MouseEnter += ellipse_MouseEnter;
                    ellipse.MouseLeave += ellipse_MouseLeave;
                    Canvas.SetTop(ellipse, 5 * j);
                    Canvas.SetLeft(ellipse, 5 * i);
                    Canvas1.Children.Add(ellipse);
                }
            }
        }
        private void ellipse_MouseEnter(object sender, MouseEventArgs e)
        {
            Ellipse ellipse = (Ellipse)sender;
            ellipse.Fill = System.Windows.Media.Brushes.Red;
            tbEname.Text = ellipse.Name;
        }
        private void ellipse_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Ellipse)sender).Fill = System.Windows.Media.Brushes.Blue;
            tbEname.Text = string.Empty;
        }
