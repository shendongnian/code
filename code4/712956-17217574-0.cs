    public class Model
    {
        [Required(ErrorMessage="Name is required")]
        [StringLength(50, ErrorMessage = "Name can not be greater than 50")]
        public string Name{ get; set; }
    }
