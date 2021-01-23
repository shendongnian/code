     protected void Page_Load(object sender, EventArgs e)
    {
        Product saleProduct = new Product("Kitchen Garbage", "49.99M", "garbage.jpg");
        Response.Write(saleProduct.GetHtml);
    }
