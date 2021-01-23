    public class Item
    {
        public Date Date { get; set; }
        public string DateString 
        {
            get { return "Today is: " + Date.Month + "/ + Date.Day; }
        }
    }
