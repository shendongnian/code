    public class Animal 
    {
        public string name;  
        public int id;  
    
        public Animal(){}
        public Animal(DataRow dr)
        {
            name = dr["Name"];
            id = dr["Id"];
        }   
    }
    
    public class Cat : Animal { }
    public class Dog : Animal { }
    public class Horse: Animal 
    {
        public int horseId { get { return id; } set { id = value; } }
    }
