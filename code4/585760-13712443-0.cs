    private ListingTransferDetail BeginListingTransferDetailReport(int PropertyTypeID)
    {
        using (IDXEntities context = new IDXEntities())
        {
            ListingTransferDetail transfer_detail =
                context.ListingTransferDetails.Create();
            transfer_detail.PropertyTypeID = PropertyTypeID;
            context.ListingTransferDetails.Add(transfer_detail);
            context.SaveChanges();
            //...
            // the following triggers lazy loading of PropertyType now
            var something = transfer_detail.PropertyType.SomeProperty;
        }
        return transfer_detail;
    }
