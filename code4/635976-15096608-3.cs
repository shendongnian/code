    public IEnumerable<object> ExtractElements(IEnumerable<object> list, IEnumerable<Type> specifiers) {
       var specifiersList = specifiers.ToList();
    
       return list.Where(t => specifiersList.Any(s => s.IsAssignableFrom(t.GetType()));
    }
    var specifiers5 = new Type[2] {typeof(B), typeof(D)};
    var list = new List<A> {new B(), new A(), new D(), new C(), new A()};
    // you can call ToArray() if you want but ForEach won't be available on that
    // and you'll need a standard foreach() loop
    var result5 = ExtractElements (list, specifiers5).ToList();
    
    result5.ForEach(Console.WriteLine);
