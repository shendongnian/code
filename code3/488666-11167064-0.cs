    public class InventoryEntry
    {
        public string Id {get;set;}
        public double NewPrice {get;set;}
        public int Quantity {get;set;}
        public string Description {get;set;}
    
        public override ToString()
        { 
               //return your specially formatted string here
        }
    }
    var items = new List<InventoryEntry>();
    //add some items
    //add them to your listbox
    //etc...
