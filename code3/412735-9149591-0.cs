    public class Program
    {
        public Program()
        {
            IKernel kernel = new StandardKernel(new MainModule());
            Form form = kernel.Get<ProductForm>();
            form.Show();
        }
    }
    public class MainModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ProductForm>().ToSelf();
            Bind<IProductService>().To<ProductService>();
            Bind<IProductDb>().To<IProductDb>();
        }
    }
    internal class ProductForm : Form
    {
        private readonly IProductService _productService;
        public ProductForm(IProductService productService)
        {
            _productService = productService;
        }
    }
    internal interface IProductService {}
    internal class ProductService : IProductService
    {
        private readonly IProductDb _productDb;
        public ProductService(IProductDb productDb)
        {
            _productDb = productDb;
        }
    }
    internal interface IProductDb {}
    internal class ProductDb : IProductDb {}
