    private void myToolStripItem_Click(object sender, EventArgs e)
    {
        var item = (ToolStripMenuItem)sender; // temp variable
        Form form = (Form)(item.formReference);
        if (form != this.ActiveMdiChild)
        {
            if (!form.Visible)
                form.Show();
            form.Activate();
            item.Selected = true; //set it to true, so the renderer will draw them differently
        }
    }
