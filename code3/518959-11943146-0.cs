    public class Item
    {
        public string Name;
        public string Widgets;
    }
    var xml = "<widgets>\r\n    <widget code=\"A\">\r\n        <foo>1</foo>\r\n    </widget>\r\n    <widge" +
    "t code=\"B\" />\r\n</widgets>";
    
    var item1 = new Item {Name = "I1", Widgets = xml};
    var item2 = new Item {Name = "I2", Widgets = xml};
    var items = new Item[] {item1, item2}.AsEnumerable();
