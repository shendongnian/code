    The ModelView 
    
       
     [Required]
            [Display(Name = "Account Number")]
            public string AccountNumber { get; set; }
        
              
            [Display(Name = "Expiration Date")]
            public IEnumerable<SelectListItem> ExpirationMonth { get; set; }
        
            
            public IEnumerable<SelectListItem> ExpirationYear { get; set; }
    
            //New property 
            [RegularExpression(@"^[^0]*$", ErrorMessage = "Select Month.")]
            public int ExpMonth{get;set;}
    
            [RegularExpression(@"^[^0]*$", ErrorMessage = "Select Year.")]
            public int ExpYear {get;set;}
