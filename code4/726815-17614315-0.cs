    public class CustomList<T> : List<T>
    {
        public override void Add(T obj) {
            base.Add(T);
            this.UpdateBuffers();
        }
    }
