    private frmSettings settings;
    private List<string> products = new List<string>();
    
    public frmMain()
    {
      InitializeComponent();
      //load products from somewhere
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
      if (settings == null)
      {
        settings = new frmSettings(this);
      }
      settings.Show();
    }
    
    private void UpdateForm()
    {
      comboBoxProducts.Items.Clear();
      comboBoxProducts.Items.AddRange(products.ToArray());
    
      //Other updates
    }
    
    public void AddProduct(string product)
    {
      products.Add(product);
      UpdateForm();
    }
