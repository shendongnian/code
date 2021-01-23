    Stack<string> sItms = new Stack<string>();
    for (int i = 0; i < lvItems.SelectedIndices.Count; ++i)
    {
        int idx = lvItems.SelectedIndices[i];
        string itm = lvItems.Items[idx].ToString();
        sItms.Push(itm);
    }
    // Our set contains D, C, A 
    // Peek() will display D
