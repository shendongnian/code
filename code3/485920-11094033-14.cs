    private void btnAutoSend_Click(object sender, EventArgs e)
    {
        timer.SynchronizingObject = this;    // Assumes `this` implements ISynchronizeInvoke
        timer.Elapsed += (s_, e_) => OnTimerElapsed(receiver);
        timer.AutoReset = true;
        timer.Enabled = true;
    }
