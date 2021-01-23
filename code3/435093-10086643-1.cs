    private void CreateMdiChild<T>(ref T t) where T : Form, new()
    {            
        if (t == null || t.IsDisposed)
        {
            t = new T();
            t.MdiParent = this;
            t.Show();
        }
        else
        {
            if (t.WindowState == FormWindowState.Minimized)
            {
                t.WindowState = FormWindowState.Normal;
            }
            else
            {
                t.Activate();
            }
        }
    }
