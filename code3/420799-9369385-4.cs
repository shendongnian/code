    [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    public class IconUrlEditor : UrlEditor
    {
        protected override string Filter
        {
            get
            {
                return "Icon Files (*.ico)|*.ico";
            }
        }
    }
