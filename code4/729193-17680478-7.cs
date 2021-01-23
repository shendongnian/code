    public class ItemDeletedEventArgs : EventArgs
    {
        public ItemDeletedEventArgs(int itemId);
        {
            ItemId = itemId;
        }
        public int ItemId { get; private set; }
    }
