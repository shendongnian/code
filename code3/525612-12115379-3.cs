    internal void Foo(int[] indices)
    {
        var bar = new Object[indices.Length];
        indices = indices.OrderBy(x => x);
        for(int i = 0; i < indices.Length; i++)
            bar[i] = BindingSource[indices[i]];    
    }
