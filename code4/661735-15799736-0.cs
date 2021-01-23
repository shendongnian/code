    public class Helper
    {
        public List<Alpha> Join(List<Alpha> alphaList, List<Bravo> bravoList)
        {
            return alphaList.Select(a => new Alpha() { key1 = a.key1, list = bravoList.Where(b => b.key1 == a.key1).ToList() }).ToList();
        }
    }
    public class Alpha
    {
        public int key1 { get; set; }
        public List<Bravo> list { get; set; }
    }
    public class Bravo
    {
        public int key1 { get; set; }
        public string someProp { get; set; }
    }
