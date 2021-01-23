         MyWpfForm form1= new MyWpfForm (this);
         form1.Show();
        public MyWpfForm (ParentClass context)
        {
            InitializeComponent();            
            parent = context;
            this.Owner = parent;
            parent.IsEnabled = false;
            
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            parent.IsEnabled = true;
            parent.Focus();
        }
