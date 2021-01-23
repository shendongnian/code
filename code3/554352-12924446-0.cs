    public partial class UserControl1
    {
        public UserControl1()
        {
            // initialise collection with '1' - doesn't appear in design time properties
            Ids = new MyCollection<int>(1);
            InitializeComponent();
        }
        public int Id { get; set; }
        public MyCollection<int> Ids { get; set; }
    }
    public class MyCollection<T> : Collection<T>
    {
        private readonly T _defaultValue;
        private bool _hasDefaultValue;
        public MyCollection(T defaultValue)
        {
            _defaultValue = defaultValue;
            try
            {
                _hasDefaultValue = false;
                Add(defaultValue);
            }
            finally
            {
                _hasDefaultValue = true;
            }
        }
        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);
            if (_hasDefaultValue)
            {
                Remove(_defaultValue);
                _hasDefaultValue = false;
            }
        }
    }
