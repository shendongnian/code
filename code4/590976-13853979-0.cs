    if (!Page.IsPostBack)
    {
      //put your binding code here
       List<CommonServices.Product> productList = commonClient.GetProductList(string.Empty, null, 1); 
       chkProduct.DataSource = productList.OrderBy(i => i.Name); 
       chkProduct.DataTextField = "ProductCodeWithName"; 
       chkProduct.DataValueField = "ID"; 
       chkProduct.DataBind();
    }
