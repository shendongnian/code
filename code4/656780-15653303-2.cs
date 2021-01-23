    public class StudentListComparer : IEqualityComparer<List<Student>>
    {
        public bool Equals(List<Student> x, List<Student> y)
        {
            return x.OrderBy(a => a.name)
                    .SequenceEqual(y.OrderBy(b => b.name));
        }
        public int GetHashCode(List<Student> obj)
        {
            return obj.Aggregate(0, (current, t) => current ^ t.GetHashCode());
        }
    }
