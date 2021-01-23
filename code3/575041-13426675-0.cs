    public sealed class Person
    {
        public Person(Reader reader)
        {
            this.Name = reader.ReadString();
            this.Sex = reader.ReadString();
        }
        
        public string Name { get; private set; }
        
        public string Sex { get; private set; }
    }
