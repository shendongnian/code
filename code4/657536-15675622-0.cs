    using Sytem;
    using System.IO;
    using System.Runtime.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
           
                Person myPerson = new Person() { Name = "Tim" };
                using (FileStream writer = new FileStream("Person.xml", FileMode.Create, FileAccess.Write))
                {
                    DataContractSerializer dcs = new DataContractSerializer(typeof(Person));
                    dcs.WriteObject(writer, myPerson);
                }
            }
        }
        [DataContract]
        class Person
        {
            private string m_name;
 
            public string Name
            {
                get
                {
                    return m_name;
                }
                set
                {
                    m_name = value;
                }
            }
        }
    }
