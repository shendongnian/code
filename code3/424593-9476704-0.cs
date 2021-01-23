     private void Form1_MouseMove(object sender, MouseEventArgs e)
     {
         if (e.Button == MouseButtons.Left)
         {
           Rect = new Rectangle(Rect.Left, Rect.Top, e.X - Rect.Left, e.Y - Rect.Top);
                    label3.Text = Rect.Left.ToString();
                    label4.Text = Rect.Top.ToString();
                    label1.Text = e.X.ToString();
                    label2.Text = e.Y.ToString();
         }
                this.Invalidate();
     }
