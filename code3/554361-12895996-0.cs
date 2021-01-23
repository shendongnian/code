    private void CtxMenu(Control parent)
    {
        foreach (Control child in parent.Controls)
        {
            if (child is TextBox)
            {
                (child as TextBox).ContextMenu = new ContextMenu(); 
            }
    }
