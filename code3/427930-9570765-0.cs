    public static class Class1
    {
        // 21ms on my machine
        public static List<T> FindAndRemove<T>(this List<T> lst, Predicate<T> match)
        {
            List<T> ret = lst.FindAll(match);
            lst.RemoveAll(match);
            return ret;
        }
    
        // 538ms on my machine
        public static List<T> MimoAnswer<T>(this List<T> lst, Predicate<T> match)
        {
            var ret = new List<T>();
            int i = 0;
            while (i < lst.Count)
            {
                T t = lst[i];
                if (!match(t))
                {
                    i++;
                }
                else
                {
                    lst.RemoveAt(i);
                    ret.Add(t);
                }
            }
            return ret;
        }
    
        // 40ms on my machine
        public static IEnumerable<T> GuvanteSuggestion<T>(this IList<T> list, Func<T, bool> predicate)
        {
            var removals = new List<Action>();
    
            foreach (T item in list.Where(predicate))
            {
                T copy = item;
                yield return copy;
                removals.Add(() => list.Remove(copy));
            }
    
            // this hides the cost of processing though the work is still expensive
            Task.Factory.StartNew(() => Parallel.ForEach(removals, remove => remove()));
        }
    }
    [TestFixture]
    public class Tester : PerformanceTester
    {
        [Test]
        public void Test()
        {
            List<int> ints = Enumerable.Range(1, 100000).ToList();
            IEnumerable<int> enumerable = ints.GuvanteSuggestion(i => i % 2 == 0);
            Assert.That(enumerable.Count(), Is.EqualTo(50000));
        }
    }
