        if (e.Item.ItemType == ListItemType.Item)
        {
            ((CompareValidator)e.Item.FindControl("cmvQuantity")).ValueToCompare = ((Product)e.Item.DataItem).SubCategory.Category.Name.Contains("Foil") && ((Product)e.Item.DataItem).SubCategory.Name.Contains("Standard") ? "150" : "250";
            ((CompareValidator)e.Item.FindControl("cmvQuantity")).ValueToCompare = ((Product)e.Item.DataItem).SubCategory.Category.Name.Contains("Printed") && ((Product)e.Item.DataItem).SubCategory.Name.Contains("Mini") ? "150" : "250";
        }
        else if (e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ((CompareValidator)e.Item.FindControl("cmvQuantity")).ValueToCompare = ((Product)e.Item.DataItem).SubCategory.Category.Name.Contains("Foil") && ((Product)e.Item.DataItem).SubCategory.Name.Contains("Standard") ? "150" : "250";
            ((CompareValidator)e.Item.FindControl("cmvQuantity")).ValueToCompare = ((Product)e.Item.DataItem).SubCategory.Category.Name.Contains("Printed") && ((Product)e.Item.DataItem).SubCategory.Name.Contains("Mini") ? "150" : "250";
        }
