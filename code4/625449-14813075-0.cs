    interface IWarehouseItem
    {
        string Name {get;} // the NAME of the PRODUCT
        int Count {get;}
        int PricePerUnit {get;}
    }
    interface IWarehouseSupplierInformation
    {
        string Name {get;} // the NAME of the SUPPLIER
        int ID {get;}
        int IDAddress {get;}
    }
    class PurchaseableItem : Entity, IWarehouseItem, IWarehouseSupplierInformation
    {
        ....
        // how to implement those different names?
         ....
        string IWarehouseItem.Name { get { this.Product.Name; } }
        ...
        string IWarehouseSupplierInformation.Name { get { this.Supplier.Name; } }
    }
