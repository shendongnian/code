        var prodInventory =
                       context.ProductInventories
                       .Where(pi => pi.ProductID.Equals(currentProduct))
                       .FirstOrDefault();
    
                    if (prodInventory != null)
                    {
                        var newinv = prodInventory.InventoryQuantity - qtyInUnits;
                        prodInventory.InventoryQuantity = newinv; // This updates the actual context object now.
                    }
