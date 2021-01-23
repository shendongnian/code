                    int radius = 3; //Set the number of pixel you wan to use here
                    //Calculate the numbers based on radius
                    int x0 = Math.Max(e.X - (radius / 2), 0),
                        y0 = Math.Max(e.Y - (radius / 2), 0),
                        x1 = Math.Min(e.X + (radius / 2), pbBackground.Width),
                        y1 = Math.Min(e.Y + (radius / 2), pbBackground.Height);
                    Bitmap bm = (Bitmap)pbBackground.Image; //Get the bitmap (assuming it is stored that way)
                    using (Graphics g = Graphics.FromImage(bm))
                    {
                        Pen p = new Pen(Color.Black, radius);
                        g.DrawLine(p, x0, y0, x1, y1);
                        p.Dispose();
                    }
                 
                    pbBackground.Refresh();
