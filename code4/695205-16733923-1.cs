    public partial class UniformGridWindow : Window {
        public UniformGridWindow() {
            //Sample Data
            GridItemsList = new List<GridItem> {
                new GridItem("Item 1"),
                new GridItem("Item 2"),
                new GridItem("Item 3"),
                new GridItem("Item 4"),
                new GridItem("Item 5"),
                new GridItem("Item 6"),
                new GridItem("Item 7"),
                new GridItem("Item 8")
            };
            InitializeComponent();
            this.DataContext = this;
        }
        public List<GridItem> GridItemsList { get; set; }
    }
    public class GridItem {
        public string ItemName { get; set; }
        public GridItem(string itemName) {
            this.ItemName = itemName;
        }
    }
