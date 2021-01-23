    public partial class Form2 : Form1
    {
        public Form2(IList<string> storage) 
            : base(storage)
        {
            InitializeComponent();
        }
    }
    public partial class Form1 : Form
    {
        protected readonly IList<string> _storage ;
        public Form1(IList<string> storage)
        {
            InitializeComponent();
            _storage = storage;
        }
    }
