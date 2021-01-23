    for (int i = Book.Count - 1; i >= 0; i--)
    {
        if (Book[i].Ischeck)
        {
            Book.RemoveAt(i);
        }
    }
