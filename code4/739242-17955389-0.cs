    private void panel_Paint(object sender, PaintEventArgs e)
    {
        myRectangle = new Rectangle(90, 90, hScrollBar.Value, vScrollBar.Value);
        System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
        messageBoxCS.AppendFormat("panel.Location.X = {0} panel.Location.Y = {1} (panel.Size.Height/2) = {2}", panel.Location.X, panel.Location.Y, e.ClipRectangle);
        //MessageBox.Show(messageBoxCS.ToString(), "Panel Paint");
        //Panel's midpoint (location(x,y) = 88,44, Size(x,y) = 182,184)
        e.Graphics.DrawRectangle(Pens.Black, myRectangle);
        if(e.ClipRectangle.Location.Y < this.Size.Height / 2 && e.ClipRectangle.Location.Y + e.ClipRectangle.Size.Height > this.Size.Height / 2)
        {
        Point startPoint = new Point(e.ClipRectangle.Location.X, this.Size.Height / 2);
        Point endPoint = new Point(e.ClipRectangle.Location.X + e.ClipRectangle.Size.Width,  this.Size.Height / 2);
        Pen dashRed = Pens.Red;
        dashRed.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
        e.Graphics.DrawLine(dashRed, startPoint, endPoint); 
        }  
    }
