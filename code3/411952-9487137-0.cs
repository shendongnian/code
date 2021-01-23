    private void GetShipments()
        {
            // Create the filter array
            filters theFilters = new filters();
            // get the order's id from its incrementId
            salesOrderEntity theOrder = this.mageObject.MageService.salesOrderInfo(this.mageObject.MageSessionId, this.Session["orderID"] as string);
            // Create the "C#" version of the associative array using a generic list
            List<associativeEntity> theEntities = new List<associativeEntity>
                {
                    new associativeEntity { key = "order_id", value = theOrder.order_id } 
                };
            // Make the generic list back into an array
            theFilters.filter = theEntities.ToArray();
            // Here are your sales orders
            salesOrderShipmentEntity[] x =
                this.mageObject.MageService.salesOrderShipmentList(this.mageObject.MageSessionId, theFilters);
