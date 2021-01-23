    public class ProductListViewModel{
        public IEnumerable<ProductListModel> products {get;set;}
    
        public string SomeOtherPotentialVariableForProductList {get;set;}
    }
    
    public class ProductListModel{
        public int ProductId { get; set; }
    
        public int ProductGroupId { get; set; }
        
        [MaxLength(255)]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Beskrivning")]
        public string Description { get; set; }
    
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Netto")]
        public decimal NetPrice { get; set; }
    }
    
    public class ProductViewModel : ProductListModel
        {
            
            public bool IsLinkedToErp { get; set; }
    
            [Required(AllowEmptyStrings = false)]
            [Display(Name = "Standard")]
            public bool IsDefault { get; set; }
    
            [MaxLength(50)]
            [Required(AllowEmptyStrings = false)]
            [Display(Name = "Artnr")]
            public string ArtNo { get; set; }
    
            [MaxLength(255)]
            [Required(AllowEmptyStrings = false)]
            [Display(Name = "Specifikation")]
            public string Specification { get; set; }
    
            [MaxLength(5)]
            [Required(AllowEmptyStrings = false)]
            [Display(Name = "Enhet")]
            public string Unit { get; set; }
    
            [MaxLength(4)]
            [Required(AllowEmptyStrings = false)]
            [Display(Name = "Konto")]
            public string Account { get; set; }
    
            public string ChUser { get; set; }
    
            public DateTime ChTime { get; set; }
    
            public string GetUpdatedDate
            {
                get { return String.Format("{0:d}", ChTime); }
            }
