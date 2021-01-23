     @{
            ViewBag.Title = "Home Page";
            //Test model to be passed to the partial view
            var products = new List<Product> { new Product{ProductName="Test product 1", ProductId=1234}};
        }
    @Html.Partial("_TestPV", products)
