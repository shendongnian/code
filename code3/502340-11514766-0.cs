        public class cboItem<T>
    {
        public cboItem(string name, T value)
        {
            this.Name = name;
            this.Value = value;
        }
        public string Name { get; set; }
        public T Value { get; set; }
        public override string ToString()
        {
            return Name == null ? "" : Name;
        }
    }
