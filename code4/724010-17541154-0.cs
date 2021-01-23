      public class CustomerModel
        {
            public int CustomerId { get; set; }
    
            public string customerName { get; set; }
    
            public List<SelectListItem> customerNameList { get; set; }
    }
    
    
    
      public class RegisterModel
        {
            public int ID { get; set; }
    
           
            public string Name { get; set; }
    
           
            public string PhoneNo { get; set; }
    
           
            public string Address { get; set; }
    
            public CustomerModel _Customer { get; set; }
    
           
        }
