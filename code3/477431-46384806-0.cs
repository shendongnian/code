    public class InventoryType
    {
        public DateTime Date { get; set; }
        public int ID { get; set; }
        public string RoomT { get; set; }
        public int Quantity { get; set; }
        public InventoryType() { }
        public InventoryType(DateTime date, int id, string roomT, int quantity)
        {
            this.Date = date;
            this.ID = id;
            this.RoomT = roomT;
            this.Quantity = quantity;
        }
        public override string ToString()
        {           
            return "Date: " + Date + "\nID: " + ID + "\nRoom Type: " + RoomT + "\nQuantity: " + Quantity;
        }
    }
