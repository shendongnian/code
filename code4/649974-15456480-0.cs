    void DisableForm()
    {
        //some fancy color
        this.BackColor = System.Drawing.Color.Khaki;
        //and disable all controls owned by form, just to be sure
        foreach (var s in this.Controls)
        {
            ((Control)s).Enabled = false;
        }
    }
