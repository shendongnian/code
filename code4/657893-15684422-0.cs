    public void SetAllCheckboxes(Control where)
    {
        foreach (Control control in where.Controls)
        {
            if (control.GetType().Name == "CheckBox")
                control.Paint += new PaintEventHandler(this.checkbox_Paint);
            else if (control.Controls.Count > 0)
                SetAllCheckboxes(control);
        }
    }
