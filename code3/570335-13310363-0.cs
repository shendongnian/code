    namespace SchoolXml
    {
        using System.Xml.Linq;
        using System.Collections.Generic;
    
        class Program
        {
            private const string xml =
    @"<educationSystem>
        <school>
            <name>Primary School</name>
            <students>
                <student id=""123456789"">
                    <name>Steve Jobs</name>
                    <otherElements>
                        <dataA>data</dataA>
                    </otherElements>
                </student>
                <student id=""987654"">
                    <name>Jony Ive</name>
                    <otherElements>
                        <dataB>data</dataB>
                    </otherElements>
                </student>
            </students>
        </school>
        <school>
            <name>High School</name>
            <students>
                <student id=""123456"">
                    <name>Bill Gates</name>
                    <otherElements>
                        <dataC>data</dataC>
                    </otherElements>
                </student>
                <student id=""987654"">
                    <name>Steve Ballmer</name>
                    <otherElements>
                        <dataD>data</dataD>
                    </otherElements>
                </student>
            </students>
        </school>
    </educationSystem>";
    
            static Dictionary<string, string> GetStudentData(XElement student)
            {
                var dict = new Dictionary<string, string>();
                EnumerateStudentData(dict, student);
                
                return dict;
            }
    
            static void EnumerateElementAttributes(Dictionary<string, string> studentData, IEnumerable<XAttribute> attributes)
            {
                foreach (var xAttribute in attributes)
                {
                    studentData[xAttribute.Name.ToString()] = (string)xAttribute;
                }
            }
    
            static void EnumerateStudentData(Dictionary<string, string> studentData, XElement currElement)
            {
                if (currElement == default(XElement)) return;
                if (!currElement.IsEmpty && !currElement.HasElements)
                {
                    studentData[currElement.Name.ToString()] = currElement.Value;
                }
                if (currElement.HasAttributes)
                {
                    EnumerateElementAttributes(studentData, currElement.Attributes());
                }
                foreach(var child in currElement.Elements())
                {
                    EnumerateStudentData(studentData, child);
                }
            }
    
            private static bool InsertStudentDataInStudentTable(XElement student)
            {
                return true;
                //throw new NotImplementedException();
            }
    
            private static void InsertStudentIdInStudentToSchoolTable(int? schoolId, string studentId)
            {
                // Do your insert
            }
    
            private static int? InsertSchoolNameInSchoolNameTable(string value)
            {
                // Do your insert if the school does not exist in Db and return the school id
                return dummyId++;
            }
    
    
            static void Main(string[] args)
            {
                
                var root = XElement.Parse(xml);
                foreach(var school in root.Elements("school"))
                {
                    var schoolName = school.Element("name");
                    int? schoolId = null;
                    if(schoolName != null && !schoolName.IsEmpty)
                    {
                        schoolId = InsertSchoolNameInSchoolNameTable(schoolName.Value);
                    }
                    foreach (var student in school.Elements("students").Elements())
                    {
                        var studentData = GetStudentData(student);
                        if (!studentData.ContainsKey("id")) continue;
                        if (!InsertStudentDataInStudentTable(student)) continue;
                        if (schoolId.HasValue)
                        {
                            InsertStudentIdInStudentToSchoolTable(schoolId, studentData["id"]);
                        }
                    }
                }
            }
    
            
            private static int dummyId;
        }
    }
