    public class ListItem
    {
        public string string1 { get; set; }
        public string string2 { get; set; }
        public string string3 { get; set; }
        public override string ToString()
        {
            return string.Join(
			","
			, string1 
			, string2 
			, string3);
        }
    }
