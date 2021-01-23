        public class FlexItem<T> where T : FlexItem<T>, new()
        {
            public FlexCollection<T> ReferenceToParentCollection;
        }
        public class FlexCollection<T> where T : FlexItem<T>, new()
        {
            public void Add(T item)
            {
            }
        }
        public class BasicItem<T> : FlexItem<BasicItem<T>>
        {
            public int A;
        }
        public class BasicCollection<T> : FlexCollection<BasicItem<T>>
        {
        }
        public class ExtendedItem<T> : BasicItem<T>
        {
            public int B;
        }
        public class ExtendedCollection<T> : FlexCollection<T> where T: FlexItem<T>, new()
        {
        }
