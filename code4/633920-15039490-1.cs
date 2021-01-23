    class Inventory
    {
        // Array to store items
        public Item[] Items { get; private set; }
        // Inventory capacity is array length
        public int Capacity { get { return (Items == null) ? 0 : Items.Length; } }
        // Constructor
        public Inventory(int capacity = 10)
        {
            SetInventorySize(capacity);
        }
        // Set size of inventory, retaining contents where possible
        public void SetInventorySize(int cap)
        {
            if (cap <= 0)
                Items = null;
            else if (Items == null)
                Items = new int[cap];
            else
                Array.Resize(ref Items, cap);
        }
        // Get index number of first free slot in inventory
        public int FirstAvail()
        {
            if (Items != null)
            {
                for (int i = 0; i < Items.Length; ++i)
                {
                    if (Items[i] == null)
                        return i;
                }
            }
            return -1;
        }
        // Add item to array, returning index or -1 on failure
        public int AddItem(Item item)
        {
            if (Items != null)
            {
                for (int i = 0; i < Items.Length; ++i)
                {
                    if (Items[i] == null)
                    {
                        Items[i] = item;
                        return i;
                    }
                }
            }
            return -1;
        }
    }
