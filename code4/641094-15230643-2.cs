    public class Model
        {
            [Display(Name = "Age")]
            [DisplayForUserType(UserType.Guest, Name = "Age (in years, round down)")]
            [ApplyDisplayForUserType("Age")]
            public string Age { get; set; }
    
            [Display(Name = "Address")]
            [DisplayForUserType(UserType.Expert, Name = "ADR Expert")]
            [DisplayForUserType(UserType.Normal, Name = "The Address Normal")]
            [DisplayForUserType(UserType.Guest, Name = "This is an Address (Guest)")]
            [ApplyDisplayForUserType("Address")]
            public string Address { get; set; }
        }
