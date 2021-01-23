    IntPtr EmbedProcess(Control Panel, string Path)
    {
        string Name = NameFromPath(Path);
        foreach (Process Task in Process.GetProcesses())
        {
            if (NameFromPath(Task.ProcessName).Contains(Name))
            {
                try { Task.Kill(); }
                catch (Exception e) {  }
            }
        }
        try
        {
            Process Task = Process.Start(Path);
            Task.WaitForInputIdle();
            IntPtr Handle = new IntPtr();
            for (int i = 0; Handle == IntPtr.Zero && i < 10; i++) { Handle = Task.MainWindowHandle; Thread.Sleep(100); }
            SetParent(Handle, Panel.Handle);
            SetWindowLong(Handle, GWL_STYLE, (int)(WS_VISIBLE + (WS_MAXIMIZE | WS_BORDER)));
            MoveWindow(Handle, 0, 0, Panel.Width, Panel.Height, true);
            Panel.Resize += new EventHandler(delegate(object sender, EventArgs e) { MoveWindow(Handle, 0, 0, Panel.Width, Panel.Height, true); });
            this.FormClosed += new FormClosedEventHandler(delegate(object sender, FormClosedEventArgs e)
            {
                SendMessage(Handle, 83, 0, 0);
                Thread.Sleep(100);
                Handle = IntPtr.Zero;
            });
            return Handle;
        }
        catch (Exception e) { MessageBox.Show(this, e.Message, "Error"); }
        return new IntPtr();
    }
