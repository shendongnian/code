            byte X;
            byte Y;
            byte Z;
            private void OnTimedEvent(object source, PaintEventArgs e)
            {
                try
                {
                    if (comport.BytesToRead > 0)
                    {
                        X = comport.ReadByte();
                        Y = comport.ReadByte();
                        Z = comport.ReadByte();
                    }
                    pictureBox1.Invalidate();
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                try
                {
                    timer1.Interval = 1;
                    pictureBox1.Invalidate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
    
            private void pictureBox1_Paint(object sender, PaintEventArgs e)
            {
                Graphics g = e.Graphics;
                Pen red = new Pen(Color.Red, 2);
                g.TranslateTransform(100, 80 - X);
                g.RotateTransform(120);
                g.DrawLine(red, new Point(100, 0 + X), new Point(100, 80 - X));
            }
