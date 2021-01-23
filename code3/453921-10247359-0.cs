    public class ViewItem<T>
    {
        [Serializable]
        public class ItemDetails
        {
            public T Type; // the generic type is inserted here
            public int Width;
            public string Text;
            public int DisplayOrder;
        }
    
        // common code that uses ItemDetails
    }
