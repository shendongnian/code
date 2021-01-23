    public class ColourViewModel
    {
        public int BrightColourGroupID { get; set; }
        [Remote("BrightColourExists", "Home", AdditionalFields = "BrightColourGroupID")]
        public string BrightColourName { get; set; }
        public int DarkColourGroupID { get; set; }
        [Remote("DarkColourExists", "Home", AdditionalFields = "DarkColourGroupID")]
        public string DarkColourName { get; set; }
    }
