    public class CustomDialogViewController : DialogViewController
    {
            public CustomDialogViewController(RootElement root)
                : base(null, true)
            {
                base.Root = root;
            }
    }
