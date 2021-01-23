    object element0 = array.Element[0].Object;
    object element1 = array.Element[1].Object;
    // Ensure at least one Object array has a non-empty value.
    if ((element0.Length > 0 && !string.IsNullOrEmpty((string)element0.Object[0].Item))
        || (element1.Length > 0 && !string.IsNullOrEmpty((string)element1.Object[1].Item)))
    {
        // ...
    }
