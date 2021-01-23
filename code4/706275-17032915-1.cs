    private int _fastSpinCounter = 50; // spin fast for this many intervals
    private void timer1_Tick(object sender, EventArgs e)
    {
        image = new Bitmap(@"C:\wheel.png");
        Wheel1.Image = (Bitmap)image.Clone();
        // not sure why you're increasing the rotation angle here
        wheelspeed1 = wheelspeed1 + 5;
        angle = wheelspeed1;
        RotateImage(Wheel1, image, angle);
        Wheel1.Refresh();
        if (_fastSpinCounter > 0)
        {
            --_fastSpinCounter;
        else if (timer1.Interval < 150)
        {
            timer1.Interval++;
        }
        else
            timer1.Enabled = false;
    }
