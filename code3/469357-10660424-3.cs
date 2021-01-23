    object CreateItem() {
        return (object)Builder.CreateItem();
    }
  
    public static dynamic __(this object o, Action<dynamic> initialize) {
        initialize(o);
        return o;
    }
    var x = CreateItem().__(i => { i.Foo = "Bar"; i.Id = 1; });
