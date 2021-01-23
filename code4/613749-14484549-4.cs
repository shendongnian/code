    public delegate void DoSomethingWithObject(Object o);
    public void RecursivelyDo(DoSomethingWithObject aDel, Control aCtrl)
    {
        aDel(aCtrl);
        foreach (Control c in aCtrl.Controls)
        {
            RecursivelyDoOnControls(aDel, c);
        }
    }
    public void RecursivelyDo(DoSomethingWithObject aDel, ToolStrip anItem)
    {
        aDel(anItem);
        foreach (ToolstripItem c in anItem.Items)
        {
            RecursivelyDo(aDel, c);
        }
    }
    public void RecursivelyDo(DoSomethingWithObject aDel, ToolStripDropDownButton anItem)
    {
        aDel(anItem);
        foreach (ToolStripItem c in anItem.DropDownItems)
        {
            RecursivelyDo(aDel, c);
        }
    }
    //and so on
