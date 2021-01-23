    protected void rptProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var validator = e.Item.FindControl("cmvQuantity") as CompareValidator;
            var product = (Product)e.Item.DataItem;
            if (validator != null)
            {
                if (product.SubCategory.Category.Name.Contains("Foil") && product.SubCategory.Category.Name.Contains("Standard"))
                {
                    validator.ValueToCompare = "150";
                }
                else if (product.SubCategory.Category.Name.Contains("Printed") && product.SubCategory.Category.Name.Contains("Mini"))
                {
                    validator.ValueToCompare = "150";
                }
                else
                {
                    validator.ValueToCompare = "250";
                }
            }
        }
    }
