    public partial class ItemTable
    {
        public ItemTable ChildItem
        {
           get
           {
              return this.ItemTable;
           }
        }
        public ItemTable ParentItem
        {
           get
           {
              return this.ItemTable1;
           }
        }
    }
