    List<Inventory> items = new List<Inventory>();
    items.Add(new Inventory() { ID = "id1", Category = "c1", Identity = "i1", Name = "n1" });
    items.Add(new Inventory() { ID = "id2", Category = "c2", Identity = "i2", Name = "n2" });
    XmlSerializer xml = new XmlSerializer(typeof(List<Inventory>),new XmlRootAttribute("Inventories"));
    xml.Serialize(stream, items);
-
    public class Inventory
    {
        public string ID;
        public string Category;
        public string Identity;
        public string Name;
    }
