    public class MyClass
    {
        private BindingList<string> original = new BindingList<string>();
        private List<string> extended = new List<string>();
        public BindingList<string> Original
        {
            get
            {
                return original;
            }
        }
        public IEnumerable<string> Extended
        {
            get
            {
                return extended;
            }
        }
        public MyClass()
        {
            original.ListChanged += OnChanging;
        }
        void OnChanging(object sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                    extended.Add(original[e.NewIndex] + "_extention");
                    break;
                case ListChangedType.ItemChanged:
                    extended[e.NewIndex] = original[e.NewIndex] + "_extention";
                    break;
                case ListChangedType.ItemDeleted:
                    extended.RemoveAt(e.NewIndex);
                    break;
                case ListChangedType.ItemMoved:
                    string tmp = extended[e.NewIndex];
                    extended[e.NewIndex] = extended[e.OldIndex];
                    extended[e.OldIndex] = tmp;
                    break;
            }
        }
    }
