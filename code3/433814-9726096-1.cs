    class StoreOrderItem : IOrderItem
    {
        void Test()
        {
            int id = ((StoreOrder)this.Parent).ID;
        }
    }
