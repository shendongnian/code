    class MyClass
    {
        public int DataFile { get; set; }
        public int _datafile;
    }
    var ob = new MyClass();
    var typ = typeof(MyClass);
    var f = typ.GetField("_datafile");
    var prop = typ.GetProperty("DataFile");
    var val = f.GetValue(ob);
    var propVal = prop.GetValue(ob);
