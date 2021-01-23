    var dict = Dictionary<ComboBox, Action<object, EventArgs>>();
    
    private void Add(ComboBox c, Action<object, EventArgs>e) {
       dict[c] = e;
    }
    
    private void Remove(ComboBox c, Action<object, EventArgs> e) {
       dict.Remove(c);
    }
