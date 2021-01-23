    Random r = new Random();
    
    for (int i = 0; i < 40; i++)
            {
                {
                    {
                        int distance = r.Next(0, 10000);
                        var rv = r.Next(0, 359);
                        var x = Math.Sin(rv * Math.PI / 180) * 225;
                        rv = r.Next(0, 359);
                        var y = Math.Cos(rv * Math.PI / 180) * 225;
                        Ellipse e = new Ellipse();
                        e.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)(counter * 5), (byte)(counter * 3), (byte)(counter * 1)));
                        e.Margin = new Thickness(y, -150 + x, 0, 0);
                        e.Width = 25;
                        e.Height = 25;
                        counter++;
                        PointsGrid.Children.Add(e);
                        //MessageBox.Show(""); // Additional line
                    }
                }
            }
