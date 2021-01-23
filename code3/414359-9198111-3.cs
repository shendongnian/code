    abstract class Drawer<T>
    {
        public abstract void Draw(T type);
        public void DrawMany(IEnumerable<T> types)
        {
            foreach (var t in types)
                Draw(t);
        }
    }
