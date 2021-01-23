    public class MyForm : Form
    {
        private IEnumerable<Product> products;
        private void MyForm_Load(object sender, EventArgs e)
        {
            this.products = ProductsDAL.GetProducts();
        }
    }
