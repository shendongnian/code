        public class Group<T> : List<T>
    {
        public Group(char name, IEnumerable<T> items) : base(items)
        {
            this.Letter = name;
      
        }
       
         
        public char Letter
        {
            get;
            set;
        }
 
    }
