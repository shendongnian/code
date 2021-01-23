    public class CustomList<T> : List<T>
    {
        public new void Add(T item) {
            base.Add(item);
            this.UpdateBuffers();
        }
    }
