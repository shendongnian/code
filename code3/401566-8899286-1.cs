    //Declare a class that inherits from ToolStripControlHost.
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.StatusStrip)]
    public class ToolStripMaskedTextBox : MyCustomToolStripControlHost
    {
        // Call the base constructor passing in a MaskedTextBox instance.
        public ToolStripMaskedTextBox() : base(CreateControlInstance()) { }
        public MaskedTextBox MaskedTextBox
        {
            get
            {
                return Control as MaskedTextBox;
            }
        }
        private static Control CreateControlInstance()
        {
            MaskedTextBox mtb = new MaskedTextBox();
            mtb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            mtb.MinimumSize = new System.Drawing.Size(100, 16);
            mtb.PasswordChar = '*';
            return mtb;
        }
    }
    public class MyCustomToolStripControlHost : ToolStripControlHost
    {
        public MyCustomToolStripControlHost()
            : base(new Control())
        {
        }
        public MyCustomToolStripControlHost(Control c)
            : base(c)
        {
        }
    }
