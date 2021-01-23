    public class CatalogItem
        {
            public string item_num { get; set; }
            public double price { get; set; }
            public ObservableCollection<Size> sizes { get; set; }
        }
        public class Size
        {
            public string sizeDesc { get; set; }
            public ObservableCollection<ColorSwatch> colorswatches { get; set; }
        }
        public class ColorSwatch
        {
            public string color { get; set; }
            public string image { get; set; }
        }
