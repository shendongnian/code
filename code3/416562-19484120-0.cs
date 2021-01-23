    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int FavoriteNumber { get; set; }
        public Person() { }
        public Person(string name, int age, int favoriteNumber) 
        { 
            this.Name = name; 
            this.Age = age; 
            this.FavoriteNumber = favoriteNumber; 
        }
    }
