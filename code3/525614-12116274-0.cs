    internal void Foo(int[] indices)
    {
        var bar = new Object[indices.Length];
        int i = 0;
        indices.OrderBy(x => x);
        foreach (int index in indices)
        {
            // now this block never gets called
            bar[i] = BindingSource[index];
            i++;
        }
    }
