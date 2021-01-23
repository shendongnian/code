    private myClass m_products = new Products();
    public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
               this.PaperBindingSource.DataSource = m_products.GetProducts();
