    public partial class MyUserControl : UserControl {
        public MyUserControl (ToolStripItemClickedEventHandler handler) {
            InitializeComponent ();
            myContextMenuStrip.ItemClicked += handler;
        }
    }
