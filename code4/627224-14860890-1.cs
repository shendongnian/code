    public partial SomeForm : Form
    {
        private SomeForm() : this(null)
        {
        }
    
        public SomeForm(SomeClass initData)
        {
            InitializeComponent();
    
            //Do some work here that does not rely on initData.           
            if(initData != null)
            {
               //do somtehing with initData, this section would be skipped over by the winforms designer.
            } 
        }
    }
