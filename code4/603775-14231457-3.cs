    Stack<string> sItms = new Stack<string>();
    for (int i = 0; i < lvItems.SelectedIndices.Count; ++i)
    {
        int idx = lvItems.SelectedIndices[(lvItems.SelectedIndices.Count - 1)-i];
        string itm = lvItems.Items[idx].ToString();
        sItms.Push(itm);
    }
    // Our Set Contains A, C, D
    // Peek() will display A
