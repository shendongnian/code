    public class Player
    {
         public Dictionary<EquipmentSlot, Item> PlayerEquipment { get; set; }
         public Player()
         {
             PlayerEquipment = new Dictionary<EquipmentSlot, Item>(7);
             PlayerEquipment.Add(EquipmentSlot.Head, null);
             // ...
         }
         // In other methods, you can use this as needed... ie:
         public void DropItem(EquipmentSlot slot)
         {
             this.PlayerEquipment[slot] = null; // Remove the item here...
         }
         //....Rest of class
