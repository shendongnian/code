    public enum Season 
    {
        [Display(Name = "The Autumn")]
        Autumn,
        [Display(Name = "The Shitty Weather")]
        Winter,
        [Display(Name = "The Tease")]
        Spring,
        [Display(Name = "The Dream")]
        Summer
    }
    public class Foo 
    {
        public Season Season = Season.Summer;
        public void DisplayName()
        {
            string seasonNameAttribute = Season.GetDisplayAttributeFrom(typeof(Season));
            Console.WriteLine("Season: {0}", seasonNameAttribute);
        } 
    }
