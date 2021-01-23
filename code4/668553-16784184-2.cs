    InitializeComponent();
    imagePath.MouseMove += new MouseEventHandler(myMouseMove);
    private void myMouseMove(object sender, MouseEventArgs e)
        {
            String[] arr = new String[2];
            var mousePos = Mouse.GetPosition(imagePath);
            arr = mousePos.ToString().Split(',');
            double x = Double.Parse(arr[0].ToString());
            double y = Double.Parse(arr[1].ToString());
            int x = (int)xx;
            int y = (int)yy;
            int left = 0;
            int top = 0;
            Console.WriteLine("Screen Cordinate-------------------------" + x + ", " + y);
                    for (int i = 0; i < n; i++)
                    {
                        if (x >= x1 && y >= y1 && x <= x2 && y <= y2
                        {                            
                            Mouse.OverrideCursor = Cursors.Hand;
                            left = left + x1;
                            top = top + y1;
                            break;
                        }
                        else
                        {
                            Mouse.OverrideCursor = Cursors.Arrow;
                        }
                    }
