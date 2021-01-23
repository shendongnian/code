    public class Human
    {
        public string Name { get; set; }
        public Human()
        {
            Name = "No name";
        }
        public Human(string name)
        {
            Name = name + " Jr.";
        }
    }
    public class Male : Human
    {
        public Male() {}
        public Male(string name) : base(name) {}
    }
    public class Female : Human
    {
        public Female() { Name = "Girl"; }
    }
    var unnamedHuman = new Human();
    //unnamedHuman.Name == "No name"
    var namedHuman = new Human("Jon");
    //namedHuman.Name == "Jon"
    var unnamedMale = new Male();
    // unnamedMale.Name == "No name"
    var namedMale = new Male("Chris");
    // namedMale.Name == "Chris Jr";
    var unnamedFemale = new Female()
    // unnamedFemale.Name == "Girl"
