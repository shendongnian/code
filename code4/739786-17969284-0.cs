    public abstract class Item
    {
        private Item other;
        public Item(Item item)
        {
            System.Diagnostics.Debug.WriteLine("Creating Item!");
            other = item;
        }
        public abstract class MiscItem : Item
        {
            public MiscItem(Item item) : base(item)
            {
            }
            public abstract class OtherItem : MiscItem
            {
                public OtherItem(Item item) : base(item)
                {
                }
                public class TransformableOther : OtherItem
                {
                    public TransformableOther() : base(null)
                    {
                    }
                    public TransformableOther(Item item) : base(item)
                    {
                    }
                }
            }
        }
    }
