    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
    
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    	
    	public int DepartmentId { get; set; }	
    
    	// You don't really need this.
        //public virtual Department Department { get; set; }
    	
    	// Create this list in your controller before sending it to the view.
    	public IEnumerable<SelectListItem> DepartmentsList { get; set; }
    }
