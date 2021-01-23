    public partial class About : Page
    {
        private IProductsRepository _productsRepository;
        public About()
        {
            Mapper.CreateMap<Product, ProductViewModel>();
            var db = new VideoGamesDataContext();
            _productsRepository = new ProductsRepository(db);
        }
        protected void Page_Load(object sender, EventArgs e)
        {            
            var products = _productsRepository.FindAll();
            ShowProducts(products);
        }
        void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int supplierID = int.Parse(DropDownList1.SelectedValue);
            var products = _productsRepository.FindBySupplierId(supplierID);
            ShowProducts(products);
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int supplierID = int.Parse(DropDownList1.SelectedValue);
            var products = _productsRepository.FindBySupplierId(supplierID);
            if(chkLike.Checked)
            {
                string name = txtProductName.Text;
                products = products.Where(p => p.ProductName.StartsWith(name));
            }
            ShowProducts(products);
        }
        public void ShowProducts(IEnumerable<Product> products)
        {
            var viewModels = Mapper.Map<IEnumerable<ProductViewModel>>(products);
            GridView1.DataSource = viewModels;
            GridView1.DataBind();
        }
    }
