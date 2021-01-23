    internal static void AssignNewArrayItem<T>(ref T[] Items, T Item) where T: Xml.CLASSNAME
    {
        if (Items != null)
        {
            Array.Resize(ref Items, Items.Length + 1);
            Items[Items.Length - 1] = Item;
        }
        else
            Items = new Xml.CLASSNAME[] { Item };
    }
