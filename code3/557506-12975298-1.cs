    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
        }
        public Person() { }
        public string Name { get; set; }
        public bool IsMale { get; set; }
        public override string ToString()
        {
            return string.Format("Name:{0};IsMale:{1}", Name, IsMale);
        }
    }
