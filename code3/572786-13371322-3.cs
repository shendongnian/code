    class Program
    {
        static void Main(string[] args)
        {
            var Student_A = new[]{
                new {StudentId = 1, Index = 23, Name = "Lucas"},
                new {StudentId = 2, Index = 71, Name = "Juan"},
                new {StudentId = 3, Index = 85, Name = "Noelia"}
            };
            var Student_B = new[]{
                new {StudentId = 6, Index = 31, Name = "Marcelo", I=0},  // extra property
                new {StudentId = 7, Index = 72, Name = "Manuel", I=0},
                new {StudentId = 8, Index = 95, Name = "Roberto", I=0}
            };
            var StudentA = (from p in Student_A.Where(a => a.StudentId != 0)
                            group p by p.Index into g
                            select g.FirstOrDefault()).Distinct().OrderBy(a => a.Index);
            var StudentB = (from p in Student_B.Where(a => a.StudentId != 0)
                            group p by p.Index into g
                            select g.FirstOrDefault()).Distinct().OrderBy(a => a.Index)
            var all = StudentA.Union(StudentB);
            all.ToList().ForEach(x=> Console.WriteLine(x.Name));
        }
