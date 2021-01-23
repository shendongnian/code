    using System.Collections.Generic;
    using System.Linq;
    internal sealed class MostRecentlyUsedList<T> : IEnumerable<T>
    {
        private readonly List<T> items;
        private readonly int maxCount;
        public MostRecentlyUsedList(int maxCount, IEnumerable<T> initialData)
            : this(maxCount)
        {
            this.items.AddRange(initialData.Take(maxCount));
        }
        public MostRecentlyUsedList(int maxCount)
        {
            this.maxCount = maxCount;
            this.items = new List<T>(maxCount);
        }
        /// <summary>
        /// Adds an item to the top of the most recently used list.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <returns><c>true</c> if the list was updated, <c>false</c> otherwise.</returns>
        public bool Add(T item)
        {
            int index = this.items.IndexOf(item);
            if (index != 0)
            {
                // item is not already the first in the list
                if (index > 0)
                {
                    // item is in the list, but not in the first position
                    this.items.RemoveAt(index);
                }
                else if (this.items.Count >= this.maxCount)
                {
                    // item is not in the list, and the list is full already
                    this.items.RemoveAt(this.items.Count - 1);
                }
                this.items.Insert(0, item);
                return true;
            }
            else
            {
                return false;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
