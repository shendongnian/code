    public class BrightColourViewModel
    {
        public int GroupID { get; set; }
        [Required]
        [Remote("BrightColourExists", "Home", AdditionalFields = "GroupID")]
        public string Name { get; set; }
    }
    
    public class DarkColourViewModel 
    {
        public int GroupID { get; set; }
        [Required]
        [Remote("DarkColourExists", "Home", AdditionalFields = "GroupID")]
        public string Name { get; set; }
    }
