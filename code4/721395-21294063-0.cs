        private void Form1_Paint(object sender, PaintEventArgs e)
            {
    System.Drawing.Rectangle rect = new Rectangle(TextBox1.Location.X, TextBox1.Location.Y, TextBox1.ClientSize.Width, TextBox1.ClientSize.Height);
                    
                    rect.Inflate(1, 1); // border thickness
                    System.Windows.Forms.ControlPaint.DrawBorder(e.Graphics, rect, Color.DeepSkyBlue, ButtonBorderStyle.Solid);
    
    }
