    public class MyController : ApiController
    {
        private SaleManager _saleManager = new SaleManager();
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _saleManager.Dispose();
            }
        }
    }
