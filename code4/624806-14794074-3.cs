    class MyViewModel
    {
        public int Column1 { get;set; }
        public int Column2 { get;set; }
    }
    grid.DataSource = objects.Select(o => new MyViewModel()
        { Column1 = o.SomeValue, Column2 = o.SomeOtherValue }).ToList();
