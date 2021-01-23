    public class Item {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Category { get; private set; }
        public float Price { get; private set; }
        public string Website { get; private set; }
        private Item() {
        }
        public static Item GetFromUrl(string url) {
           var o = WebRequest(url);
            return new Item() {
                Id = (int)o["Id"],
                Name = (string)o["Name"],
                Category = (string)o["Category"],
                Price = (float)o["Price"],
                Website = (string)o["Website"],
            };
        }
    }
