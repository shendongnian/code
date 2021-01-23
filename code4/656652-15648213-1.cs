    // start
    System.Drawing.ImageAnimator.Animate(txImage.Image, OnFrameChanged);
    // stop
    System.Drawing.ImageAnimator.StopAnimate(txImage.Image, OnFrameChanged);
    private void OnFrameChanged(object sender, EventArgs e)
    {
       // frame change
    }
