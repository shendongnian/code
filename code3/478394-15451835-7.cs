     public List<PanelSerialList> PanelSerialByLocationAndStock(string locationCode, byte storeLocation, string itemCategory, string itemCapacity, byte agreementType, string packageCode)
     {
           string panelSerialByLocationAndStockQuery = "SELECT isws.ItemSerialNo,  im.ItemModel " +
            "FROM Inv_ItemMaster im   " +
            "INNER JOIN  " +
            "Inv_ItemStockWithSerialNoByLocation isws  " +
            "   ON im.ItemCode = isws.ItemCode   " +
            "		WHERE isws.LocationCode = '" + locationCode + "' AND  " +
            "	isws.StoreLocation = " + storeLocation + " AND  " +
            "	isws.IsAvailableInStore = 1 AND " +
            "	im.ItemCapacity = '" + itemCapacity + "' AND " +
            "	isws.ItemSerialNo NOT IN ( " +
            "			Select sp.PanelSerialNo From Special_SpecialPackagePriceForResale sp  " +
            "			Where sp.PackageCode = '" + packageCode + "' )";
    
    
                
        context.Database.SqlQuery<PanelSerialList>(panelSerialByLocationAndStockQuery).ToList();
    
    
    }
