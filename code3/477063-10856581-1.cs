    public class Root<T>
    {
        private List<T> children = null;
        public Root(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public List<T> Children
        {
            get
            {
                if (children == null)
                {
                    children = new List<T>();
                }
                return children;
            }
        }
    }
    Root<int> intRoot = new Root<int>("IntRoot");
    intRoot.Children.Add(23);
    intRoot.Children.Add(42);
    Root<string> stringRoot = new Root<string>("StringRoot");
    stringRoot.Children.Add("String1");
    stringRoot.Children.Add("String2");
    stringRoot.Children.Add("String3");
    stringRoot.Children.Add("String4");
