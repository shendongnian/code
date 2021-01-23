    DateTime startTime; int animationTime;
    void AnimateProgress(int ms) {
        if (ms <= 0) return;
        progressBar1.Value = 0;
        animationTime = ms;
        startTime = DateTime.Now;
        Tmr.Start();
    }
    private void Tmr_Tick(object sender, EventArgs e) {
        progressBar1.Value = (int)(Math.Min((DateTime.Now - startTime).TotalMilliseconds / animationTime, 1) * 100);
        if (progressBar1.Value == 100) Tmr.Stop();
    }
