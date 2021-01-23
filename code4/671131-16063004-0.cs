    Form f2 = new Form2();
    f2.Shown += ToggleControls;
    f2.Closing += ToggleControls;
    f2.Show();
    public void ToggleControls(object o, sender e)
    {
        foreach(Control c in this.Controls)
        {
            c.Enabled = !c.Enabled;
        }
    }
