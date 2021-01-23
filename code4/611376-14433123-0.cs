    public Detached(PictureBox map)
    {
        Thread HoverCheck = new Thread(() =>
        {
            while (true)
            {
                if (this.Bounds.Contains(Cursor.Position))
                {
                    ToggleButtons(true);
                }
                else
                {
                    ToggleButtons(false);
                }
                Thread.Sleep(50);
            }
        });
        HoverCheck.Start();
    }
        
    void ToggleButtons(bool enable)
    {
        if (InvokeRequired)
        {
            Invoke(new MethodInvoker(() => ToggleButtons(enable)));
            return;
        }
        this.attach.Visible = enable;
        this.move.Visible = enable;
        this.pictureBox1.Visible = enable;
    }
