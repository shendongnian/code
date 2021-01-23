    protected void Page_Load(object sender, EventArgs e)
    {
        _lvCategoryProduct.DataBound += _lvCategoryProduct_DataBound;
    }
    protected void _lvCategoryProduct_DataBound(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(_dpProducts.QueryStringField))
        {
            Common.SetDataPagerUrls(_dpProducts);
        }
    }
