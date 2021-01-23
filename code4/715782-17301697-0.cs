    private void Form1_Paint(object sender, PaintEventArgs e)
            {
                System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(100, 100, 200, 200);
                e.Graphics.DrawEllipse(System.Drawing.Pens.Black, rectangle);
                e.Graphics.DrawRectangle(System.Drawing.Pens.Red, rectangle);
            }
