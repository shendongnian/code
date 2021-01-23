    public partial SomeForm : Form
    {
        private SomeForm() : this(null)
        {
        }
    
        public SomeForm(SomeClass initData)
        {
            InitializeComponent();
    
            if(initData != null)
            {
               //Being called via user code, do somtehing with initData.
            } 
        }
    }
