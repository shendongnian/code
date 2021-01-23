    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitGrid();
        }
        private void InitGrid()
        {
            dgProducts.AutoGenerateColumns = true;
                        
            BindingList<Product> products = new BindingList<Product>();
            products.Add(new Product("Eggs"));
            products.Add(new Product("Milk"));
            products.Add(new Product("Bread"));
            products.Add(new Product("Butter"));
            dgProducts.DataSource = products;
        }
        
    }
