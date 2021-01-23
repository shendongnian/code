       public class Student
        {
            public int StudentID { get; set;}
            public string Name { get; set;}
            public List<Fee> Fees {get;set;}
        }
        public class Fee
        {
            public int FeeID { get; set;}
            public string FeeName { get; set;}
            public DateTime FeeDueDate { get; set; }
        }
