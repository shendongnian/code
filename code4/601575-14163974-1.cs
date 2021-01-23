    public sealed class BadRecords
    {
        private static BadRecords _instance;
        public static BadRecords Instance
        {
            if (_instance == null) { _instance = new BadRecords(); }
            return _instance;
        }
        private BadRecords() { this.List = new List<MyObject>(); }
        public List<MyObject> List { get; set; }
    }
    public class MyObject
    {
     private string myString;
     public string MyString
     {
       get
       {
         return this.myString;
       }
       set
       {
         if (value.Length > 15) { BadRecords.Instanse.List.Add(this); }
         else { this.myString = value.Remove(15).PadRight(15); }
       }
    }
