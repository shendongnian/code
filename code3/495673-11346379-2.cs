    // Swaps the references themselves for reference-types.
    void Swap<T>(T a, T b)
    {
        var tmp = a;
        a = b;
        b = tmp;
    }
    // Swaps the properties between two Item objects.
    void SwapItems(Item a, Item b)
    {
        Swap(a.OriginalItemPosition, b.OriginalItemPosition);
        Swap(a.OriginalItemRectangle, b.OriginalItemRectangle);
    }
