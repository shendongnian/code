    //in Form2
    
    public partial class Form2 : Form
    {
        private Product product = null;
        public Form2()
        {
            InitializeComponent();
        }
        public Product GetNewProduct()
        {
            return product;
        }
    
    
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (IsValidData())
            {
                if (rbBook.Checked)
                {
                    product = new Book(txtName.Text, txtLName.Text,
                        Convert.ToDouble(txtAssessGrade.Text), Convert.ToDouble(txtAssigGrade.Text), txtEmail.Text);
                    this.Close();
                }
            }
        }
    
        private bool IsValidData()
        {
            return true;
        }
    }
    
    //Modify in Form1:
    
     
    
           public partial class Form1 : Form
                {
                    private ArrayList products = new ArrayList();
                    public Form1()
                    {
                        InitializeComponent();
                    }
            
                    private void button1_Click(object sender, EventArgs e)
                    {
            
                        
                        Form2 frmUpdate = new Form2();
                        frmUpdate.ShowDialog();
                        Product product = frmUpdate.GetNewProduct();
                        products.Add(product);
                        FillProductListBox();
                        
                    }
                    private void FillProductListBox()
                    {
                        lstPerson.Items.Clear();
                        foreach (Product p in products)
            
                            lstPerson.Items.Add(p.GetDisplayText("\t"));
            
                    }    
                }
