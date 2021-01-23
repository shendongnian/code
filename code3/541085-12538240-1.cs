    Unhandled Exception: System.ArgumentException: At least one object must implement IComparable.
       at System.Collections.Comparer.Compare(Object a, Object b)
       at System.Linq.EnumerableSorter`2.CompareKeys(Int32 index1, Int32 index2)
       at System.Linq.EnumerableSorter`1.QuickSort(Int32[] map, Int32 left, Int32 right)
       at System.Linq.EnumerableSorter`1.Sort(TElement[] elements, Int32 count)
       at System.Linq.OrderedEnumerable`1.<GetEnumerator>d__0.MoveNext()
       at System.Linq.Enumerable.Count[TSource](IEnumerable`1 source)
       at Program.Main()
