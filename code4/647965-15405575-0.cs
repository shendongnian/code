    private bool CheckMinimized(string name)
    {
        FormCollection fc = Application.OpenForms;
        foreach (Form frm in fc)
        {
            if (frm.Text == name || frm.State == FormState.Minimized)
            {
                return true;
            }
        }
        return false;
    }
