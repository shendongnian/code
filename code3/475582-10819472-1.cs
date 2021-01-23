    public Class Property<T>
    {
        public Property(string name, bool visible, T value)
        {
            Name = name;
            Visible = visible;
            Value = value;
        }
        string Name { get; set; }
        bool Visible { get; set; }
        T Value { get; set; }
    }
