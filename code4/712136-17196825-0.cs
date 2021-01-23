    int index = Alt.FindIndex(t => t.Item1 == tbAlt.Text);
    if (index != -1)
    {
       // Modify
       Alt[index] = Tuple.Create(tbAlt.Text, "NewText");
       // Remove:
       Alt.RemoveAt(index);
    }
