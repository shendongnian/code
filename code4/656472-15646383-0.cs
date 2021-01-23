    public class LineItem
    {
       //common properties of LineItem
    }
    
    public class PurchaseLineItem : LineItem 
    {
         public PurchaseOrder PurchaseOrder { get; set; }
    }
    
    public class InvoiceLineItem : LineItem 
    {
         public Invoice Invoice { get; set; }
    }
