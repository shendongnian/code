    public partial class xRef_CodesMetadata
            {
                public int CodeID { get; set; }
                public int CTB_ID { get; set; }
        
                [Required(ErrorMessage = "Please type a name")]
                [Display(Name = "Code Name")]
                [Column(TypeName = "Code Name")]
                public string CodeName { get; set; }
        
                [Required(ErrorMessage = "Please type a Description")]
                [Display(Name = "Description")]
                [Column(TypeName = "Description")]
                public string Description { get; set; }     
            }
