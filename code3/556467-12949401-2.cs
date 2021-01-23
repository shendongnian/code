    The ModelView 
    
       
     [Required]
            [Display(Name = "Account Number")]
            public string AccountNumber { get; set; }
        
              
            [Display(Name = "Expiration Date")]
            public IEnumerable<SelectListItem> ExpirationMonth { get; set; }
        
            
            public IEnumerable<SelectListItem> ExpirationYear { get; set; }
    
            //New property 
            [Required( ErrorMessage="Some Error Meassage")]
            public int ExpirationMonth{get;set;}
    
            [Required( ErrorMessage="Some Error Meassage")]
            public int ExpirationYear {get;set;}
