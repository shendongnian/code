    public partial class DeckControl : UserControl
    {
        public DeckControl()
        {
            InitializeComponent();
        }
    
        private int myVar;
        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }
    }
