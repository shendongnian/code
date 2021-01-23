        class SimplePerson
        {
            public string Name { get; set; }
            public bool IsSelected { get; set; }
        }
        BindingList<SimplePerson> source = new BindingList<SimplePerson>();
        void InitGrid()
        {
            source.Add(new SimplePerson() { Name = "John", IsSelected = false });
            source.Add(new SimplePerson() { Name = "Gabriel", IsSelected = true });
            gridControl.DataSource = source;
        }
