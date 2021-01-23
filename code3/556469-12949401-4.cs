    The ModelView 
    
       
     [Required]
            [Display(Name = "Account Number")]
            public string AccountNumber { get; set; }
        
              
            [Display(Name = "Expiration Date")]
            public IEnumerable<SelectListItem> ExpirationMonth { get; set; }
        
            
            public IEnumerable<SelectListItem> ExpirationYear { get; set; }
    
            //New property 
            [Required( ErrorMessage="Some Error Meassage")]
            public int ExpMonth{get;set;}
    
            [Required( ErrorMessage="Some Error Meassage")]
            public int ExpYear {get;set;}
