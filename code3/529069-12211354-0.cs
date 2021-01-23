    protected void rptProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
           Product productInstance = e.Item.DataItem as Product; //safely type cast
           CompareValidator cmvQuantity = e.Item.FindControl("cmvQuantity") as CompareValidator; //safely type cast
           if (cmvQuantity != null && productInstance != null) //check if type cast suceeded and/or control was found.
           {
               if((productInstance.SubCategory.Category.Name.Contains("Foil") && productInstance.SubCategory.Name.Contains("Standard")) ||
                  (productInstance.SubCategory.Category.Name.Contains("Printed") && productInstance.SubCategory.Name.Contains("Mini"))
               {
                   cmvQuantity.ValueToCompare = "150";
               }
               else
               {
                   cmvQuantity.ValueToCompare = "250";
               }
           }
        }
    }
