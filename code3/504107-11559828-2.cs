    public class CustomClass : IComparable<CustomClass>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        private string _CreatedDate;
        public string CreatedDate
        {
            private get
            {
                return _CreatedDate;
            }
            set
            {
                Created = DateTime.Parse(value);
                _CreatedDate = value;
            }
        }
        public CustomClass(string id, string name, string created)
        {
            Id = id;
            Name = name;
            CreatedDate = created;
        }
        public int CompareTo(CustomClass other)
        {
            return Created.CompareTo(other.Created);
        }
    }
    public class ComparingObservableCollection<T> :  ObservableCollection<T> where T : IComparable<T>
    {
        // this fuction presumes that list is allways sorted and index is not used at all
        protected override void InsertItem(int index, T item)
        {
            if (!Items.Contains<T>(item))
            {
                var bigger = Items.First<T>(F => F.CompareTo(item) > 0);
                index = Items.IndexOf(bigger)-1;
                base.InsertItem(index, item);
            }
        }
    }
