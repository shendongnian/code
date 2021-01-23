        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        private BindingSource source = new BindingSource();
        private void Form1_Load(object sender, EventArgs e)
        {
            var items = new List<Person>();
            items.Add(new Person() { Id = 1, Name = "Gabriel" });
            items.Add(new Person() { Id = 2, Name = "John" });
            items.Add(new Person() { Id = 3, Name = "Mike" });
            source.DataSource = items;
            gridControl.DataSource = source;
            source.ListChanged += source_ListChanged;
        }
        void source_ListChanged(object sender, ListChangedEventArgs e)
        {
            label1.Text = String.Format("{0} items", source.List.Count);
        }
