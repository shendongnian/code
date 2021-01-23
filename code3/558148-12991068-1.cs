    void toolTip1_Draw(object sender, DrawToolTipEventArgs e) {
         Font f = new Font("Arial", 10.0f);
         toolTip1.BackColor = System.Drawing.Color.Red;
         e.DrawBackground();
         e.DrawBorder();
         e.Graphics.DrawString(e.ToolTipText, f, Brushes.Black, new PointF(2, 2));
     }
