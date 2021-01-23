    private void LoadSizes()
    {
        List<Size> sizes = new List<Size>();
        sizes.Add(new Size("2X-Large", "2XL", 3));
        sizes.Add(new Size("Small", "S", 1));
        sizes.Add(new Size("5X-Large", "5XL", 4));
        sizes.Add(new Size("Medium", "M", 2));
    
        List<string> sizesShortNameOrder = sizes.OrderBy(s => s.Order).Select(s => s.ShortName).ToList();
        //If you want to use the size class:
        //List<Size> sizesOrder = sizes.OrderBy(s => s.Order).ToList();
    }
    
    public class Size
    {
        private string _name;
        private string _shortName;
        private int _order;
    
        public string Name
        {
            get { return _name; }
        }
    
        public string ShortName
        {
            get { return _shortName; }
        }
    
        public int Order
        {
            get { return _order; }
        }
    
        public Size(string name, string shortName, int order)
        {
            _name = name;
            _shortName = shortName;
            _order = order;
        }
    }
