    if ((array.Element[0].Length != 0 && HasValue(array.Element[0].Object))
        || (array.Element[1].Length > 1 && HasValue(array.Element[1].Object)))
    {
        // ...
    }
    // <summary>
    // Returns true if the specified string array contains a non-empty value at
    // the specified index.
    // </summary>
    private bool HasValue(System.Array array, int index)
    {
        return array.Length > index && 
            !string.IsNullOrEmpty((string)array.Object[index].Item);
    }
