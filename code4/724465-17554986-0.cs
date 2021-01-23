    private void panel1_Paint(object sender, PaintEventArgs e)
        {            
            using (System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(panel1.ClientRectangle, Color.FromArgb(100, 204, 222,246), Color.FromArgb(190,220,255) , 90))
            {
                e.Graphics.FillRectangle(brush,new Rectangle(2,2,panel1.ClientSize.Width - 4, panel1.ClientSize.Height - 4));
            }
            ControlPaint.DrawBorder(e.Graphics, panel1.ClientRectangle, Color.FromArgb(133, 164, 202), ButtonBorderStyle.Solid);
            ControlPaint.DrawBorder(e.Graphics, new Rectangle(1,1, panel1.ClientSize.Width - 2, panel1.ClientSize.Height - 2), 
                Color.FromArgb(100,220,240,255), 1, ButtonBorderStyle.Solid,
                Color.White, 1, ButtonBorderStyle.Solid,
                Color.FromArgb(100,220,240,255), 1, ButtonBorderStyle.Solid,
                Color.FromArgb(100,204,222,250), 1, ButtonBorderStyle.Solid);
            StringFormat sf = new StringFormat() { LineAlignment = StringAlignment.Center };
            e.Graphics.DrawString("I love .NET", panel1.Font, Brushes.Black, panel1.ClientRectangle, sf);
        } 
