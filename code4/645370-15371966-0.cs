    public class Fruit
    {
        public String Name {get; set;}
        public Object Tag {get; set;} //change Object to YourType if using only one type
        public Fruit(String sInName, Object inTag)
        {
            this.Name=sInName;
            this.Tag=inTag;
        }
    }
