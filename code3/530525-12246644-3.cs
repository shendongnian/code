     public void Process(Arguments arguments)
     {
     Product productToProcess;
     var productRepository = new ProductRepository 
          { ConnectionString = arguments.ConnectionString};
     if (!string.IsNullOrEmpty(arguments.ProductName))
        productToProcess = productRepository.GetByName(arguments.ProductName);
     else
        productToProcess = productRepository.GetById(arguments.ProductId);
     // ....
    }
