    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<SampleClass>();
            // add some items
            var distinctItems = list.Distinct(new SampleClass());
        }
    }
    public class SampleClass : EqualityComparer<SampleClass>
    {
        public string Text { get; set; }
        public override bool Equals(SampleClass x, SampleClass y)
        {
            if (x == null || y == null) return false;
            return x.Text == y.Text;
        }
        public override int GetHashCode(SampleClass obj)
        {
            if (obj == null) return 0;
            if (obj.Text == null) return 0;
            return obj.Text.GetHashCode();
        }
    }
