    public void PerformMouseClick(MouseEventArgs e)
    {
        this.OnMouseClick(e);
    }
`
    Form frm = new Form();
    frm.PerformMouseClick(new MouseEventArgs(MouseButtons.Left, 1, 100, 100, 0));
