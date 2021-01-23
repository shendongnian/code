      public class Program
    {
        static void Main(string[] args)
        {
            StringWriter sr1 = new StringWriter();
            var baseSerializer = new XmlSerializer(typeof(Human));
            var human = new Human {Age = 30, Continent = Continent.America};
            baseSerializer.Serialize(sr1, human);
            Console.WriteLine(sr1.ToString());
            Console.WriteLine();
            StringWriter sr2 = new StringWriter();
            var specialSerializer = new XmlSerializer(typeof(SpecialHuman));
            var special = new SpecialHuman() {Age = 40, Continent = Continent.Africa};
            specialSerializer.Serialize(sr2, special);
            Console.WriteLine(sr2.ToString());
            Console.ReadLine();
        }
        public enum Continent
        {
            Europe,
            America,
            Africa
        }
        public class Human
        {
            public int Age { get; set; }
            public Continent Continent { get; set; }
        }
        [XmlRoot("Human")]
        public class SpecialHuman : Human, IXmlSerializable 
        {
            #region Implementation of IXmlSerializable
            /// <summary>
            /// This method is reserved and should not be used. When implementing the IXmlSerializable interface, you should return null (Nothing in Visual Basic) from this method, and instead, if specifying a custom schema is required, apply the <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute"/> to the class.
            /// </summary>
            /// <returns>
            /// An <see cref="T:System.Xml.Schema.XmlSchema"/> that describes the XML representation of the object that is produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)"/> method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)"/> method.
            /// </returns>
            public XmlSchema GetSchema()
            {
                throw new NotImplementedException();
            }
            public void ReadXml(XmlReader reader)
            {
                throw new NotImplementedException();
            }
            public void WriteXml(XmlWriter writer)
            {
                writer.WriteElementString("Age", Age.ToString());
                switch(Continent)
                {
                    case Continent.Europe:
                    case Continent.America:
                        writer.WriteElementString("Continent", this.Continent.ToString());
                        break;
                    case Continent.Africa:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            #endregion
        }
    }
