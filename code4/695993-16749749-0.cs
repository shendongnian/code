    public class Customer
    {
        public int ID { get; set; }
    
        //EF will create the relationship since the property is named class+id
        //the following is not necessary, is just good practice
        //if this is omitted EF will create a Order_Id on its own
        public int OrderID { get; set; }
    
        // Some other properties
    
        public virtual Order Order { get; set; }
    }
    
    public class Order
    {    
        public int ID { get; set; }
    
        // no need to include the id property
        // Some other properties
    
        public virtual Customer Customer { get; set; }
    }
