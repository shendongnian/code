         private void button3_Paint(object sender, PaintEventArgs e)
                {
        
                    SolidBrush br = new SolidBrush(Color.Blue);
                    Pen pen = new Pen(br);
                    pen.Width = 3;
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                      // to draw left border
                    e.Graphics.DrawLine(pen, new Point(0, 0), new Point(0, this.button3.Width));
                    SolidBrush drawBrush = new SolidBrush(ForeColor); //Use the ForeColor property
                    // Draw string to screen.
                    e.Graphics.DrawString("Sample", Font, drawBrush, 5f, 3f);
                    this.button3.Text = "";
        }
