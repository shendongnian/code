    if (!IsPostBack)
    {
         txtid.Value = pro.getId().ToString();
         txtmodel.Text = pro.getModal();
         txtname.Text = pro.getName();
         cbCategory.SelectedValue = pro.getCategory();
         txtprice.Text = pro.getPrice().ToString();
         txtDescription.Text = pro.getDescription();
    }
