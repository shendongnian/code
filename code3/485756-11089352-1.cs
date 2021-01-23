    namespace XmlTestApp
    {
        [XmlRoot(Namespace="xmltestapp", TypeName="Student")]
        public class Student
        {
            private string studentId;
    
            public string FirstName;
            public string MI;
            public string LastName;
    
            public Student()
            {
                //Just provided for making Serialization work as obj.GetType() needs parameterless constructor.
            }
    
            public Student(String studentId)
            {
                this.studentId = studentId;
            }
    
        }
    }
    ...
            Student s = new Student("2");
            s.FirstName = "Cad";
            s.LastName = "dss";
            s.MI = "Dsart";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(s.GetType());
            System.Xml.Serialization.XmlSerializationNamespaces ns = new System.Xml.Serialization.XmlSerializationNamespaces();
            ns.Add("XmlTestApp", "xmltestapp");
            TextWriter txtW=new StreamWriter(Server.MapPath("~/XMLFile1.xml"));
            x.Serialize(txtW,s, ns); //add the namespace provider to the Serialize method
