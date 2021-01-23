    /// The beginning of a form resize
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void this_beginResize(object sender, EventArgs e)
    {
        lastLocation = this.Location;
        this.ResizeBegin -= new EventHandler(this_beginResize);
        panelPlanning.Paint -= new PaintEventHandler(panelPlanning_Paint);
        scrollvalue = panel1.VerticalScroll.Value;
        lastHeight = panel1.Height;
        this.SuspendLayout();
        SuspendDrawing(panelTimeline);
        SuspendDrawing(panelPipeLine);
        SuspendDrawing(panel1);
    }
    /// <summary>
    /// Called when the form is done resizing
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void this_SizeChanged(object sender, EventArgs e)
    {
        if (this.Location != lastLocation)
        {
            lastLocation = this.Location;
            return;
        }
        panelTimeline.Controls.Clear();
        sub = dtPickerEnd.Value - dtPickerStart.Value;
        addDayLabels(sub);
        panelUsers.Controls.Clear();
        addUserLabels();
        panelPlanning.Paint += new PaintEventHandler(panelPlanning_Paint);
        ResumeDrawing(panel1);
        ResumeDrawing(panelTimeline);
        ResumeDrawing(panelPipeLine);
        this.ResumeLayout();
        if (userList.Count > 0)
        {
            panelPlanning.Height = userList.Count * userHeight;
            panelUsers.Height = userList.Count * userHeight;
        }
        if (nrResources == 0)
        {
            nrResources = 10;
        }
        userHeight = panel1.Height / nrResources;
        panel1.VerticalScroll.Value = scrollvalue * panel1.Height / lastHeight;
        panel1.VerticalScroll.Enabled = false;
        panelPlanning.Controls.Clear();
        addPlanning();
        this.ResizeBegin += new EventHandler(this_beginResize);
        panel1.VerticalScroll.Enabled = true;
        panel1.VerticalScroll.Value = scrollvalue * panel1.Height / lastHeight;
    }
    /// <summary>
    /// Handles maximize and restore
    /// </summary>
    /// <param name="m"></param>
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 0x0112) // WM_SYSCOMMAND
        {
            // Check your window state here
            if (m.WParam == new IntPtr(0xF030) || m.WParam == new IntPtr(0xF120)) // Maximize event - SC_MAXIMIZE from Winuser.h
            {
                this.ResizeBegin -= new EventHandler(this_beginResize);
                panelPlanning.Paint -= new PaintEventHandler(panelPlanning_Paint);
                scrollvalue = panel1.VerticalScroll.Value;
                if (panel1.Height != 0)
                {
                    lastHeight = panel1.Height;
                }
                this.SuspendLayout();
                SuspendDrawing(panelTimeline);
                SuspendDrawing(panelPipeLine);
                SuspendDrawing(panel1);
                panel1.VerticalScroll.Enabled = false;
            }
        }
        base.WndProc(ref m);
        if (m.Msg == 0x0112) // WM_SYSCOMMAND
        {
            // Check your window state here
            if (m.WParam == new IntPtr(0xF030) || m.WParam == new IntPtr(0xF120)) // Maximize event - SC_MAXIMIZE from Winuser.h
            {
                panelTimeline.Controls.Clear();
                sub = dtPickerEnd.Value - dtPickerStart.Value;
                addDayLabels(sub);
                panelUsers.Controls.Clear();
                addUserLabels();
                panelPlanning.Paint += new PaintEventHandler(panelPlanning_Paint);
                ResumeDrawing(panel1);
                ResumeDrawing(panelTimeline);
                ResumeDrawing(panelPipeLine);
                this.ResumeLayout();
                if (userList.Count > 0)
                {
                    panelPlanning.Height = userList.Count * userHeight;
                    panelUsers.Height = userList.Count * userHeight;
                }
                if (nrResources == 0)
                {
                    nrResources = 10;
                }
                userHeight = panel1.Height / nrResources;
                panel1.VerticalScroll.Value = scrollvalue * panel1.Height / lastHeight;
                panel1.VerticalScroll.Enabled = false;
                panelPlanning.Controls.Clear();
                addPlanning();
                this.ResizeBegin += new EventHandler(this_beginResize);
                panel1.VerticalScroll.Enabled = true;
                panel1.VerticalScroll.Value = scrollvalue * panel1.Height / lastHeight;
            }
        }
    }
