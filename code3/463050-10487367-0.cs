        static void Main(string[] args)
        {
            var list = Enumerable.Range(0, 10).Reverse().Select(x => new SampleClass { IntProperty = x, StringProperty = x + "String", DateTimeProperty = DateTime.Now.AddDays(x * -1) });
            SortContainer<SampleClass> container = new SortContainer<SampleClass>();
            container.Add("Int", x => x.IntProperty);
            container.Add("String", x => x.StringProperty);
            container.Add("DateTime", x => x.DateTimeProperty);
            var sorter = container.GetSorterFor("Int");
            sorter.Sort(list).ForEach(x => Console.WriteLine(x.IntProperty));
            Console.ReadKey();
        }
        public class SampleClass
        {
            public int IntProperty { get; set; }
            public string StringProperty { get; set; }
            public DateTime DateTimeProperty { get; set; }
        }
        public class SortContainer<TSource>
        {
            protected Dictionary<string, ISorter<TSource>> _sortTypes = new Dictionary<string, ISorter<TSource>>();
            public void Add<TKey>(string name, Func<TSource, TKey> sortExpression)
            {
                Sorter<TSource, TKey> sorter = new Sorter<TSource, TKey>(sortExpression);
                _sortTypes.Add(name, sorter);
            }
            public ISorter<TSource> GetSorterFor(string name)
            {
                return _sortTypes[name];
            }
        }
        public class Sorter<TSource, TKey> : ISorter<TSource>
        {
            protected Func<TSource, TKey> _sortExpression = null;
            public Sorter(Func<TSource, TKey> sortExpression)
            {
                _sortExpression = sortExpression;
            }
            public IOrderedEnumerable<TSource> Sort(IEnumerable<TSource> sourceEnumerable)
            {
                return sourceEnumerable.OrderBy(_sortExpression);
            }
        }
        public interface ISorter<TSource>
        {
            IOrderedEnumerable<TSource> Sort(IEnumerable<TSource> sourceEnumerable);
        }
