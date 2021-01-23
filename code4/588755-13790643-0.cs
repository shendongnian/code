    TElement[] array = null;
    int length = 0;
    ICollection<TElement> is2 = source as ICollection<TElement>;
    if (is2 != null)
    {
         length = is2.Count;
         if (length > 0)
         {
             array = new TElement[length]; // create new array
             is2.CopyTo(array, 0); // copy items
         }
    }
