    public class Register
    {
        [Required(ErrorMessage="Option is required")]
        public string option;
        public IEnumerable<SelectListItem> Options;
        public Register()
        {
             this.Options = new []
             { 
                new SelectListItem{Value="value", Text="text"}
                ////...
             };
        }
    }
    public ActionResult Register()
    {
       Register mm = new Register();
    }
 
    
