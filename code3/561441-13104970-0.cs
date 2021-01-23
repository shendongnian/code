    public class LandingPresenter : ILandingPresenter
    {            
        private ILandingView _view;
        private IProductService _productService { get; set; }
    
        public LandingPresenter(ILandingView view, IProductService _productService)
        {
            ....
        }
    }
