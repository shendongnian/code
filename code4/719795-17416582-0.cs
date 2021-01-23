    using System;
    using System.Data;
    using System.Collections.Generic;
    namespace SO17416111
    {
        class Class
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        // Note that definition of Class and Student only differ by name
        // I'm assuming that Student can/will be expanded latter. 
        // Otherwise it's possible to use a single class definition
        class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        class Program
        {
            static void Main()
            {
                DataTable table = GetData();
                Dictionary<Class, List<Student>> d = new Dictionary<Class, List<Student>>();
                foreach (DataRow dr in table.Rows)
                {                
                    // If it's possible to get null data from the DB the appropriate null checks
                    // should also be performed here
                    // Also depending on actual data types in your DB the code should be adjusted as appropriate
                    Class key = new Class {Id = (int) dr["ClassID"], Name = (string) dr["ClassName"]};
                    Student value = new Student { Id = (int)dr["StudentID"], Name = (string)dr["StudentName"] };
                    if (!d.ContainsKey(key))
                    {
                        d.Add(key, new List<Student>());
                    }
                    d[key].Add(value);
                }
                foreach (var s in d.Keys)
                {
                    foreach (var l in d[s])
                    {
                        Console.Write(s.Id + "-" + s.Name + "-" + l.Id + "-" + l.Name + "\n");
                    }
                }
            }
            // You don't need this just use your datatable whereever you obtain it from
            private static DataTable GetData()
            {
                DataTable table = new DataTable();
                table.Columns.Add("ClassID", typeof (int));
                table.Columns.Add("ClassName", typeof (string));
                table.Columns.Add("StudentID", typeof (int));
                table.Columns.Add("StudentName", typeof (string));
                table.Rows.Add(1, "A", 1000, "student666");
                table.Rows.Add(2, "B", 1100, "student111");
                table.Rows.Add(5, "C", 1500, "student777");
                table.Rows.Add(1, "A", 1200, "student222");
                table.Rows.Add(2, "B", 1080, "student999");
                return table;
            }
        }
    }
