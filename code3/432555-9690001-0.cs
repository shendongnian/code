        public MyForm()
        {
            InitializeComponent();
            InitializeDates();            
        }
        public void InitializeDates()
        {
            var today = DateTime.Today.ToString("dd/MM/yyyy");
            textBox3.Text = today;
        }
