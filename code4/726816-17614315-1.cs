    public class CustomList<T> : List<T>
    {
        public void AddWithUpdate(T obj) {
            base.Add(obj);
            this.UpdateBuffers();
        }
    }
