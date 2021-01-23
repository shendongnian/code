    public class Program
    {
        static void Main(string[] args)
        {
            var aString = new MyString() {Description = "desc", Id = 1, Name = "Ja", Status = "st", Value = "Val"};
    
            var myStrings = new List<MyString>() {aString};
    
    
            foreach (MyString myString in myStrings)
            {
                //The Name of the Item with the Id 1 is Ja. It's Description is desc. It has the Value val and the Status st.
                var outputStringVal = myString.ToString();
                //
            }
        }
    }
    
    public class MyString 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public string Status { get; set; }
    
        public override string ToString()
        {
            return String.Format("The Name of the Item with the Id {0} is {1}. It's Description is {2}. It has the Value {3} and the Status {4}.", this.Id, Name, Description, Value, Status);
        }
    }
