    class Person
    {
        public string Name { get; set; }
        public virtual void Speak()
        {
            Console.Write("Hello I am a person");
        }
        public static Person GenerateRandomInstance()
        {
            var o = new Person();
            RandomizeProperties(o);
            return o;
        }
        protected static void RandomizeProperties(Person o)
        {
            // randomize Person properties here
        }
    }
    class Student : Person
    {
        public override void Speak()
        {
            Console.Write("Hello I am a student");
        }
        // note the use of the 'new' keyword
        new public static Student GenerateRandomInstance()
        {
            var o = new Student();
            RandomizeProperties(o);
            return o;
        }
        protected static void RandomizeProperties(Student o)
        {
            Person.RandomizeProperties(o);
            
            // randomize Student properties here
        }
    }
