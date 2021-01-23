            var coll = new ObservableCollection<myItem>();
            coll.Add(new myItem() { Id = 0, Name = "zz" });
            coll.Add(new myItem() { Id = 3, Name = "bb" });
            coll.Add(new myItem() { Id = 1, Name = "aa" });
            var sortedById = from item in coll
                             orderby item.Id
                             select item;
            var sortedByName = from item in coll
                             orderby item.Name
                             select item;
            coll = new ObservableCollection<myItem>(sortedById);
            coll = new ObservableCollection<myItem>(sortedByName);
    class myItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
