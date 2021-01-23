        public class PersonDB
    {
        private const string path = @"..\..\Persons.xml";
    
        public static List<Person> GetPersons()
        {
            List<Person> persons = new List<Person>();
    
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
    
            XmlReader xmlIn = XmlReader.Create(path, settings);
    
            if (xmlIn.ReadToDescendant("Student"))
            {
                do
                {
    
                    Student student = new Student();
                    xmlIn.ReadStartElement("Student");
                    student.FirstName = xmlIn.ReadElementContentAsString();
                    student.LastName = xmlIn.ReadElementContentAsString();
                    student.Email = xmlIn.ReadElementContentAsString();
                    student.AssessmentGrade = xmlIn.ReadElementContentAsInt();
                    student.AssignmentGrade = xmlIn.ReadElementContentAsInt();
    
                    persons.Add(student);
                } while (xmlIn.ReadToNextSibling("Student"));
    
            }
    
            else if (xmlIn.ReadToDescendant("Teacher"))
            {
                do
                {
                   
                    Teacher teacher = new Teacher();
                    xmlIn.ReadStartElement("Teacher");
                    teacher.FirstName = xmlIn.ReadElementContentAsString();
                    teacher.LastName = xmlIn.ReadElementContentAsString();
                    teacher.Email = xmlIn.ReadElementContentAsString();
                    teacher.RoomNumber = xmlIn.ReadElementContentAsInt();
    
                    persons.Add(teacher);
                } while (xmlIn.ReadToNextSibling("Teacher"));
            }
    
            if (xmlIn.ReadToDescendant("Person"))
            {
                do
                {
                    Person person = new Person();
    
                    xmlIn.ReadStartElement("Person");
                    person.FirstName = xmlIn.ReadElementContentAsString();
                    person.LastName = xmlIn.ReadElementContentAsString();
                    person.Email = xmlIn.ReadElementContentAsString();
    
                    persons.Add(person);
                } while (xmlIn.ReadToNextSibling("Person"));
            }
    
    
            xmlIn.Close();
    
            return persons;
        }
       } 
