    public class MyModel
    {
        [Display(Name = "Property 1")]
        [Required(ErrorMessage = "Property cannot be empty")]
        public int Property1 { get; set; }
        // ...
        [Display(Name = "Property n")]
        [Required(ErrorMessage = "Property cannot be empty")]
        public string Propertyn { get; set; }        
    }
