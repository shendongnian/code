    public class MyRepository
    {
        List<object> repo;
        public MyRepository()
        {
            repo = new List<object>();
        }
        public void Add<T>(string name, T value)
        {
            if (!repo.OfType<MyDictionary<T>>().Any())
                repo.Add(new MyDictionary<T>());
            var dict = repo.OfType<MyDictionary<T>>().FirstOrDefault();
            dict[name] = value;
        }
        public T GetValue<T>(string name)
        {
            if (!repo.OfType<MyDictionary<T>>().Any())
                return default(T);//or throw
            else
            {
                var dict = repo.OfType<MyDictionary<T>>().FirstOrDefault();
                return dict[name];
            }
        }
    }
