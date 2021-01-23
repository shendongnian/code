    public class StackOverflow_10524470
    {
        public class Animal
        {
            [XmlText]
            public string Name { get; set; }
        }
        public class Dog : Animal { }
        public class Cat : Animal { }
        public class Frog : Animal { }
        public class Root
        {
            [XmlElementAttribute(Order = 4, ElementName = "animals")]
            public Animals animals;
        }
        public class Animals
        {
            [XmlElementAttribute(Order = 4)]
            [XmlElement("Frog", typeof(Frog))]
            [XmlElement("Cat", typeof(Cat))]
            [XmlElement("Dog", typeof(Dog))]
            public List<Animal> lines = new List<Animal>();
        }
        public static void Test()
        {
            MemoryStream ms = new MemoryStream();
            XmlSerializer xs = new XmlSerializer(typeof(Root));
            Root root = new Root
            {
                animals = new Animals
                {
                    lines = new List<Animal> 
                    { 
                        new Dog { Name = "Fido" },
                        new Cat { Name = "Fluffy" },
                        new Frog { Name = "Singer" },
                    }
                }
            };
            xs.Serialize(ms, root);
            Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray()));
        }
    }
