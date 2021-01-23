    public class NumberOfEmployees : IXmlSerializable
    {
        public int[] NumEmployees { get; set; }
    
        // Constructor initializes array to size of "EmployeeType"
        public NumberOfEmployees()
        {
            int size = Enum.GetValues(typeof(EmployeeType)).Length;
            this.NumEmployees = new int[size];
        }
    
        public XmlSchema GetSchema()
        {
            return null;
        }
    
        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            NumEmployees[(int)EmployeeType.Lawyer] = int.Parse(reader.ReadElementString("Lawyer"));
            NumEmployees[(int)EmployeeType.Doctor] = int.Parse(reader.ReadElementString("Doctor"));
            NumEmployees[(int)EmployeeType.Engineer] = int.Parse(reader.ReadElementString("Engineer"));
            reader.ReadEndElement();
        }
    
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("Lawyer", NumEmployees[(int)EmployeeType.Lawyer].ToString());
            writer.WriteElementString("Doctor", NumEmployees[(int)EmployeeType.Doctor].ToString());
            writer.WriteElementString("Engineer", NumEmployees[(int)EmployeeType.Engineer].ToString());
        }
    }
