    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.IO;
    
    namespace XMLStudent
    {
        class Program
        {
            static void Main(string[] args)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("st.xml");
                List<StudentPunishment> sp = new List<StudentPunishment>();
                foreach (XmlNode nod in doc.SelectNodes(@"studentPunishmentsTables/studentPunishmentsTable"))
                {
                    StudentPunishment s = new StudentPunishment();
                    s.FromSemester = nod.ChildNodes[0].InnerText;
                    s.FromSemesterDesc = nod.ChildNodes[1].InnerText;
                    s.IssueDate = nod.ChildNodes[2].InnerText;
                    s.Note = nod.ChildNodes[3].InnerText;
                    s.Penalty = nod.ChildNodes[4].InnerText;
                    s.Semester = nod.ChildNodes[5].InnerText;
                    s.SemesterDesc = nod.ChildNodes[6].InnerText;
                    s.ToSemester = nod.ChildNodes[7].InnerText;
                    s.ToSemesterDesc = nod.ChildNodes[8].InnerText;
                    sp.Add(s);
                }
                Console.WriteLine(sp[0].IssueDate);
                Console.Read();
            }
        }
        class StudentPunishment
        {
            public string FromSemester { get; set; }
            public string FromSemesterDesc { get; set; }
            public string IssueDate { get; set; }
            public string Note { get; set; }
            public string Penalty { get; set; }
            public string Semester { get; set; }
            public string SemesterDesc { get; set; }
            public string ToSemester { get; set; }
            public string ToSemesterDesc { get; set; }
        }
    }
