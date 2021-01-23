class MyTreeView : TreeView
{
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 0x0203)
        {
            m.Result = IntPtr.Zero;
        }
        else
        {
            base.WndProc(ref m);
        }
    }
}
