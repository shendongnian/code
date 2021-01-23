    public class Extras
    {
        public static Extras CreatFrom(XElement extra)
        {
            return new Extras {
                Id = (int)extra.Attribute("id"),
                Quantity = (int)extra.Element("Qty"),
                Description = (string)extra.Element("Desc")
            };
        }
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
