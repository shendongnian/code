        /// <summary>
        /// Inserts a new value into a sorted collection.
        /// </summary>
        /// <typeparam name="T">The type of collection values, where the type implements IComparable of itself</typeparam>
        /// <param name="collection">The source collection</param>
        /// <param name="item">The item being inserted</param>
        public static void InsertSorted<T>(this Collection<T> collection, T item) where T : IComparable<T>
        {
          InsertSorted(collection, item, Comparer<T>.Create((x, y) => x.CompareTo(y)));
        }
    
        /// <summary>
        /// Inserts a new value into a sorted collection.
        /// </summary>
        /// <typeparam name="T">The type of collection values</typeparam>
        /// <param name="collection">The source collection</param>
        /// <param name="item">The item being inserted</param>
        /// <param name="ComparerFunction">An IComparer to comparer T values, e.g. Comparer&lt;T&gt;.Create((x, y) =&gt; (x.Property &lt; y.Property) ? -1 : (x.Property &gt; y.Property) ? 1 : 0)</param>
        public static void InsertSorted<T>(this Collection<T> collection, T item, IComparer<T> ComparerFunction)
        {
          if (collection.Count == 0)
          {
            // Simple add
            collection.Add(item);
          }
          else if (ComparerFunction.Compare(item, collection[collection.Count - 1]) >= 0)
          {
            // Add to the end as the item being added is greater than the last item by comparison.
            collection.Add(item);
          }
          else if (ComparerFunction.Compare(item, collection[0]) <= 0)
          {
            // Add to the front as the item being added is less than the first item by comparison.
            collection.Insert(0, item);
          }
          else
          {
            // Otherwise, search for the place to insert.
            int index = Array.BinarySearch(collection.ToArray(), item, ComparerFunction);
            if (index < 0)
            {
              // The zero-based index of item if item is found; 
              // otherwise, a negative number that is the bitwise complement of the index of the next element that is larger than item or, if there is no larger element, the bitwise complement of Count.
              index = ~index;
            }
            collection.Insert(index, item);
          }
        }
