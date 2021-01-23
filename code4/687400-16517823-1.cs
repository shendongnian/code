    Dictionary<string, InventoryItem> inventory = new Dictionary<string, InventoryItem>();
    inventory.["television"] = new InventoryItem 
                                    { 
                                         Name = "television", Type = "large", Amount = 5,
                                         CanHave = 3, Clear = false, Effect = "dynamic",
                                         Modifier = 0.8, Weight = 20
                                    });
