    internal void Foo(int[] indices)
    {
        var bar = new Object[indices.Length];
        int i = 0;
        indices = indices.OrderBy(x => x).ToArray();
        foreach (int index in indices)
        {
            // now this block gets called
            bar[i] = BindingSource[index];
            i++;
        }
    }
