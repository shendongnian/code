    class MyViewModel
    {
        public int Column1 { get;set; }
        public int Column2 { get;set; }
        ....
        private SomeType _obj;
        
        public MyViewModel(SomeType obj)
        {
            _obj = obj;
        }
        
        public SomeType GetModel()
        {
            return _obj;
        }
    }
    grid.DataSource = objects.Select(o => new MyViewModel(o)
        { Column1 = o.SomeValue, Column2 = o.SomeOtherValue }).ToList();
