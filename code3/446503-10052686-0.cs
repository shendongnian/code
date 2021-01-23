    public class NoHScrollTree : TreeView {
    protected override CreateParams CreateParams {
    get {
        CreateParams cp = base.CreateParams;
        cp.Style |= 0x8000; // TVS_NOHSCROLL
        return cp;
    }
    } }
