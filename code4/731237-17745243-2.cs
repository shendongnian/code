    public ActionResult Compare(int id)
    {
         ProductViewModel viewModel = new ProductViewModel
         {
              Product = productRepository.GetBuId(id),
              Products = productRepository.GetAll()
         };
    
         return View(viewModel);
    }
