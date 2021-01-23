     public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            ComboBox comboBox1 = new ComboBox();
            comboBox1.Height = 23;
            comboBox1.Width = 200;
            GroupStyle style = new GroupStyle();
            style.HeaderTemplate = (DataTemplate)this.FindResource("groupStyle");
            comboBox1.GroupStyle.Add(style);
            comboBox1.DisplayMemberPath = "Item";
            List<CategoryItem<string>> items = new List<CategoryItem<string>>();
            items.Add(new CategoryItem<string> { Category = "Warm Colors", Item = "Orange" });
            items.Add(new CategoryItem<string> { Category = "Warm Colors", Item = "Red" });
            items.Add(new CategoryItem<string> { Category = "Warm Colors", Item = "Pink" });
            items.Add(new CategoryItem<string> { Category = "Cool Colors", Item = "Blue" });
            items.Add(new CategoryItem<string> { Category = "Cool Colors", Item = "Purple" });
            items.Add(new CategoryItem<string> { Category = "Cool Colors", Item = "Green" });
            //Need the list to be ordered by the category or you might get repeating categories
            ListCollectionView lcv = new ListCollectionView(items.OrderBy(w => w.Category).ToList());
            //Create a group description
            lcv.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
            comboBox1.ItemsSource = lcv;
            myGrid.Children.Add(comboBox1);  //myGrid is the name of the parent control
        }
    }
    public class CategoryItem<T>
    {
        public T Item { get; set; }
        public string Category { get; set; }
    }
    
