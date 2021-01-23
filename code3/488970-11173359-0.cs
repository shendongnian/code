    void DoWork()
    {
        Func<Action, string, Tuple<Action, string>> toT = 
            (a, s) => new Tuple<Action, string>(a, s);
    
        var map = new Dictionary<CheckBox, Tuple<Action, string>>
        {
            {FooCheckBox, toT(Foo, "Foo")},
            {BarCheckBox, toT(Bar, "Bar")},
            {BazCheckBox, toT(Baz, "Baz")},
        };
        
        foreach (var x in map.Keys)
            if (x.Checked)
            {
                map[x].Item1();
                Console.WriteLine(map[x].Item2 + " was called");
            }
    }
