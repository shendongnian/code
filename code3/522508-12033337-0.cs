    public partial class CustomControl1 : Control
    {
        public CustomControl1()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor,System.Design, Version=2.0.0.0, Culture=neutral,PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public StringCollection Attribute { get; set; }
        public string Element { get; set; }
    }
