    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var students = new[] {
                    new Student()   
                        { StudentID = 0, Name = "Mark", fees =
                            new List<Fee>() {
                                new Fee() { FeeID=1, FeeName="Books", FeeDueDate=new DateTime(2014,06,25), FeeAmount = 1.30 },
                                new Fee() { FeeID=2, FeeName="Tuition", FeeDueDate=new DateTime(2013,03,21), FeeAmount = .30 },
                                new Fee() { FeeID=3, FeeName="Sports Equipment", FeeDueDate=new DateTime(2013,03,18), FeeAmount = .80 },
                                new Fee() { FeeID=4, FeeName="School Dorm", FeeDueDate=new DateTime(2013,07,26), FeeAmount = 0}
                            }
                        },
                    new Student()
                        { StudentID = 1, Name = "Tom", fees =
                            new List<Fee>() {
                                new Fee() { FeeID=2, FeeName="Books", FeeDueDate=new DateTime(2014,06,20), FeeAmount = 1.50 },
                                new Fee() { FeeID=4, FeeName="School Dorm", FeeDueDate=new DateTime(2013,03,26), FeeAmount = 4.00 }
                            }
                        }
                    };
                
                var sorted = (from student in students
                             select new
                             {
                                 stud = student.StudentID,
                                 name = student.Name,
                                 feesum = student.fees.Sum(x => x.FeeAmount),
                                 fees =
                                     from fee in student.fees
                                     orderby fee.FeeDueDate ascending
                                     select fee
                             }).OrderByDescending(s => s.feesum);
    
                foreach (var item in sorted)
                {
                    Console.WriteLine("stud[{0}] => {1}, Fees: {2}", item.stud, item.name, item.feesum);
                    foreach (var f in item.fees)
                    {
                        Console.WriteLine(f.ToString());
                    }
                    Console.WriteLine();
                }
            }
        }
    
        
        public class Student
        {
            public int StudentID {get; set;}
            public string Name {get; set;}
            public List<Fee> fees {get; set;}
        }
    
        public class Fee
        {
            public int FeeID {get; set;}
            public string FeeName {get; set;}
            public DateTime FeeDueDate { get; set; }
            public double FeeAmount { get; set; }
    
            public override string ToString()
            {
     	         return String.Format("FeeID={0,2}, FeeName={1,20}, FeeDueDate={2}", FeeID, FeeName, FeeDueDate);
            }
        }
    }
