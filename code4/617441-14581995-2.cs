    int sequence = 0;
    private void timer1_Tick(object sender, EventArgs e)
    {
        using(var still = new Bitmap(form.Width, form.Height))
        {
            form.DrawToBitmap(still, new Rectangle(new Point(0, 0), still.Size));
            still.Save(String.Format(@"c:\still_{0}.gif", sequence++), ImageFormat.Gif);
        }
    }
