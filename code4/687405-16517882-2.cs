    public class InventoryItem
    {
        public string ItemType { get; set; }
        public string ItemName { get; set; }
        public int ItemAmount { get; set; }
        public int ItemACanHave { get; set; }
        public bool ItemClear { get; set; }
        public string ItemEffect { get; set; }
        public float ItemModifier { get; set; }
        public int ItemWeight { get; set; }
    }
        
    public class Radio : InventoryItem
    {
    }
    public class Television : InventoryItem
    {
    }
    // TODO: add your derived classes
