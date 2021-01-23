    public class ViewModel
    {
        [Required]
        [RegularExpression("\d{2}-\d{2}-\d{4}\s\d{2}:\d{2}:\d{2}")]
        public string MyDateTime { get; set; }
    
        public Model ToPoco()
        {
            return new Model {
                MyDateTime = DateTime.Parse(this.MyDateTime, "MM-dd-yyyy H:mm:ss")
            };
        }
    }
    public class Model
    {
        DateTime MyDateTime { get; set; }
    }
