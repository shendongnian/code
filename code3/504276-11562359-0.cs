    public class Dog
    {
        public int Age { get; set; }
        private int dogYears { get { return Age * 7; } }
        public void DisplayDogYears(TextWriter writer)
        {
            writer.WriteLine(
                "The dog is {0} years old in human years.", 
                this.dogYears);
        }
    }
