    public ActionResult List()
    {
         ProductListViewModel viewModel = new ProductListViewModel
         {
              Products = productRepository.GetAllProducts()
         };
    
         return View(viewModel);
    }
