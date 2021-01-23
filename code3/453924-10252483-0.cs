    public class BaseViewItem<T> where T : struct
    {
        [Serializable]
        public class ItemDetails
        {
            public T Type;
            public int Width;
            public string Text;
            public int DisplayOrder;
        }
        public FirstViewItem()
        {
            // ...
        }
        public List<ItemDetails>()
        {
            // code here ...
        }
    }
    public class FirstViewItem : BaseViewItem<FirstItemType>
    {
        // class-specific code...
    }
    public class SecondViewItem : BaseViewItem<SecondItemType>
    {
        // class-specific code...
    }
    
    public enum FirstItemType
    {
        None = 0, A, B, C
    }
    public enum SecondItemType
    {
        None = 0, X, Y, Z
    }
