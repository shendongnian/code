    public class myContact
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public myContact(string name, string number)
        {
            this.Name = name;
            this.Number = number;
        }
        public override string ToString()
        {
            return Name;
        }
    }
