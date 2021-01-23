    private IList<ColorItem> CreateBrushes()
        {
            var brushes = new List<ColorItem>
            {
                new ColorItem { Brush = new SolidColorBrush(Color.FromArgb(255,27,161,226)), Name = "blue" },    
                new ColorItem { Brush = new SolidColorBrush(Color.FromArgb(255,160,80,0)), Name = "brown" },     
                new ColorItem { Brush = new SolidColorBrush(Color.FromArgb(255, 51,153,51)), Name = "green" },   
                new ColorItem { Brush = new SolidColorBrush(Color.FromArgb(255,162,193,57)), Name = "lime" },   
                new ColorItem { Brush = new SolidColorBrush(Color.FromArgb(255,216,0,115)), Name = "magenta" }, 
                new ColorItem { Brush = new SolidColorBrush(Color.FromArgb(255,240,150,9)), Name = "mango" },   
                new ColorItem { Brush = new SolidColorBrush(Color.FromArgb(255,230,113,184)), Name = "pink" },  
                new ColorItem { Brush = new SolidColorBrush(Color.FromArgb(255,162,0,255)), Name = "purple" },  
                new ColorItem { Brush = new SolidColorBrush(Color.FromArgb(255,229,20,0)), Name = "red" },      
                new ColorItem { Brush = new SolidColorBrush(Color.FromArgb(255,0,171,169)), Name = "teal" },    
            };
            return brushes;
        }
    
    
    
    public class ColorItem
    {
        public SolidColorBrush Brush { get; set; }
        public string Name { get; set; }
    }
