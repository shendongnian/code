    public class MyViewModel
    {
        [AtLeastOneRequired("Email", "Fax", "Phone", ErrorMessage = "At least Email, Fax or Phone is required")]
        public string Email { get; set; }
        [AtLeastOneRequired("Email", "Fax", "Phone", ErrorMessage = "At least Email, Fax or Phone is required")]
        public string Fax { get; set; }
        [AtLeastOneRequired("Email", "Fax", "Phone", ErrorMessage = "At least Email, Fax or Phone is required")]
        public string Phone { get; set; }
    }
