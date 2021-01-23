    /// <summary>
    /// Iterates through items in the grid and updates the selected vendor 
    /// list with any selections or deselections on the current page
    /// </summary>
    private void UpdateSelectedItems()
    {
        var selectedVendors = new List<int>();
        foreach (GridItem Item in grdVendors.Items)
        {
            if (Item is GridDataItem)
            {
                int VendorID = (int)((GridDataItem)Item).GetDataKeyValue("SupplierID");
                if (Item.Selected)
                {
                    if (!selectedVendors.Contains(VendorID))
                        selectedVendors.Add(VendorID);
                    continue;
                }
                selectedVendors.Remove(VendorID);
            }
        }            
    }
