    private bool CheckMinimized(string name)
    {
        FormCollection fc = Application.OpenForms;
        foreach (Form frm in fc)
        {
            if (frm.Text == name || frm.State == FormWindowState.Minimized)
            {
                return true;
            }
        }
        return false;
    }
