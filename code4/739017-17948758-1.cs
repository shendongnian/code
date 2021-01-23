     public class CustomerModel
        {
            public int CustomerId { get; set; }
    
            [StringLength(9), Required, DisplayName("Social security number")]
            [RegularExpression(@"\d{3}-\d\d-\d{4}", ErrorMessage = "Invalid social security number")]
            public string customerName { get; set; }
    
            public List<MyListItems> customerNameList { get; set; }
    }
