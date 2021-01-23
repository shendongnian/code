    [Serializable()]    //Set this attribute to all the classes that want to serialize
    public class Employee : ISerializable 
    {
        public int EmpId;
        public string EmpName;
        
        //Default constructor
        public Employee()
        {
            EmpId = 0;
            EmpName = null;
        }
    }
     XmlSerializer serializer = new XmlSerializer(typeof(Employee));
     TextWriter writer = new StreamWriter(filename);
     Employee objEmp = new Employee();
     serializer.Serialize(writer, objEmp);
     writer.Close();
