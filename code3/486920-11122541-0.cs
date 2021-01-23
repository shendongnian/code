    class MyClass
    {
        public int _datafile;
    }
    var ob = new MyClass();
    var typ = typeof(MyClass);
    var f = typ.GetField("_datafile");
    var val = f.GetValue(ob);
