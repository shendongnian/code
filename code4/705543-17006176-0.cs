    public enum Quarters
        {
            First,
            Second,
            Third,
            Fourth
        }
        class Courses
        {
            private Quarters ThisQuarter { get; private set; }
            private List<Tuple<Quarters, List<Courses>>> SchoolProgram = new List<Tuple<Quarters, List<Courses>>>();
    
            public int year { get; private set; }
            public string name { get; private set; }
    
            private Courses()
            {
                //load list from database or xml
                //each tuple has one quarters and a list
                // of associated courses
                //SchoolProgram.Add(new Tuple<Quarters, List<Courses>>(Quarters.First, new List<Courses>(){new Courses(2010,"Math",Quarters.First),
                //                                                                                       new Courses(2010,"English",Quarters.First),
                //                                                                                       new Courses(2010,"Physics",Quarters.First)}));
            }
    
            public Courses(int year,string name,Quarters q)
            {
                this.year = year;
                this.name = name;
                ThisQuarter = q;
    
            }
    
            public Courses GetCourse()
            {
                return SchoolProgram.Find(q => q.Item1 == ThisQuarter).Item2.Single(c => (c.year == this.year && c.name == this.name));
            }
        }
    
        public class Transcript
        {
            private List<Courses> SchoolProgram = new List<Courses>();
    
            public Transcript()
            {
                //maybe aditional logic here
            }
            
            public void AddCourse(int year,string name,Quarters q)
            {
                Courses c = new Courses(year, name, q);
                SchoolProgram.Add(c.GetCourse());
            }
        }
