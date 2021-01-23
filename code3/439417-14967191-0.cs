    public void CreateMdiChild<T>(Form f) where T : Form, new()
    {
        foreach (Form frm in f.MdiChildren)
        {
            if (frm.GetType() == typeof(T))
            {
                        
                if (frm.WindowState == FormWindowState.Minimized)
                {
                    frm.WindowState = FormWindowState.Normal;
                }
                else
                {
                    frm.Activate();
                }
                return;
            }
                    
        }
        T t = new T();
        t.MdiParent = f;
        t.Show();
    }
