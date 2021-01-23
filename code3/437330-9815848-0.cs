    Debug.Assert(a.Count == b.Count);
    
    for (int i = 0; i < a.Count; i++)
    {
       c.Add(a[i]);
       c.Add(b[i]);
    }
    Debug.Assert(c.Count == (a.Count + b.Count));
