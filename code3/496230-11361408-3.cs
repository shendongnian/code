    public class MyViewModel
    {
        [Required]
        [DisplayName("Role")]
        public string SelectedRole { get; set; }
        public IEnumerable<SelectListItem> Roles 
        {
           get
           {
               return new[]
               {
                   new SelectListItem { Value = "Author", Text = "Author" },
                   new SelectListItem { Value = "Underwriter", Text = "Underwriter" }
               };
           }
        }
    }
