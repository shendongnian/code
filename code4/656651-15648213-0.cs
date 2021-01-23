    // start
    System.Drawing.ImageAnimator.Animate(txImage.Image, (s,e) => OnFrameChanged(s,e));
    // stop
    System.Drawing.ImageAnimator.StopAnimate(txImage.Image, (s, e) => OnFrameChanged(s, e));
    private void OnFrameChanged(object sender, EventArgs e)
    {
       // frame change
    }
