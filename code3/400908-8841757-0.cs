    public class OrderCollection : System.Collections.ObjectModel.KeyedCollection<uint, Order>
    {
        protected override uint GetKeyForItem(Order item)
        {
            return item.Order_ID;
        }
    }
