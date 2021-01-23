    class MyData
    {
        [Browsable(false)]
        public int _MyProp { get; set; }
        [Browsable(true)]
        public string MyProp
        {
            get
            {
                 return _MyProp.ToString("#,##0");
            }
            set
            {
                 _MyProp = int.Parse(value.Replace(".", ""));
            }
        }
    }
