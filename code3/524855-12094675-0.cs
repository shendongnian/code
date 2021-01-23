    public string vendorId;
    public string categoryId;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            dropDownListVendor.DataSource = CatalogAccess.GetVendors();
            dropDownListVendor.DataBind();
            vendorId = dropDownListVendor.SelectedValue;
    
            dropDownListCategory.DataSource = CatalogAccess.GetCategoriesInVendor(vendorId);
            dropDownListCategory.DataBind();
            categoryId = dropDownListCategory.SelectedValue;
        }
        else
        {
            vendorId = dropDownListVendor.SelectedValue;
            categoryId = dropDownListCategory.SelectedValue;
        }
    }
    
    protected void dropDownListVendor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            dropDownListCategory.DataSource = CatalogAccess.GetCategoriesInVendor(vendorId);
            dropDownListCategory.DataBind();
        }
    }
