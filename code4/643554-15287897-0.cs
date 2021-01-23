    public partial class BaseForm : System.Windows.Forms.Form
        {
            public BaseForm()
            {
                InitializeComponent();
            }
    
            public void  CommonMethod()
            {
                
            }
        }
    public partial class FormA : BaseForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void LocalMethod()
        {
            CommonMethod();
        }
       
    }
    public partial class FormB : BaseForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void LocalMethod()
        {
            CommonMethod();
        }
       
    }
