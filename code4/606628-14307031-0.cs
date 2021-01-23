    public partial class Form2 : Form1
    {
        private readonly IList<string> _storage ;
        public Form2(IList<string> storage) 
            : base(storage)
        {
            InitializeComponent();
        }
    }
    public partial class Form1 : Form
    {
        private readonly IList<string> _storage ;
        public Form1(IList<string> storage)
        {
            InitializeComponent();
            _storage = storage;
        }
    }
