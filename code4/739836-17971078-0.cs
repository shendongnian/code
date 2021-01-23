    //First you have to do some things with your scrollbars, place this in your Form constructor would be OK
    vScrollBar1.Maximum = yourImage.Height - panel1.Height;
    hScrollBar1.Maximum = yourImage.Width - panel1.Width;
    hScrollBar1.Value = hScrollBar1.Maximum;
    
    vScrollBar1.Visible = vScrollBar1.Maximum > 0;
    hScrollBar1.Visible = hScrollBar1.Maximum > 0;
    //To prevent/eliminate flicker, do this
    typeof(Panel).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(panel1, true, null);
    //------------------------
    Point leftTop = Point.Empty;
    int lastV, lastH;
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
      e.Graphics.DrawImage(yourImage, leftTop);
    }
    //The ValueChanged event handler of your vScrollBar1
    private void vScrollBar1_ValueChanged(object sender, EventArgs e)
    {
            leftTop.Offset(0,  - vScrollBar1.Value + lastV);
            lastV = vScrollBar1.Value;
            panel1.Invalidate();
    }
    //The ValueChanged event handler of your hScrollBar1
    private void hScrollBar1_ValueChanged(object sender, EventArgs e)
    {
            leftTop.Offset(lastH + hScrollBar1.Value - hScrollBar1.Maximum, 0);
            lastH = hScrollBar1.Maximum - hScrollBar1.Value;
            panel1.Invalidate();
    }
