    public partial class MainWindow : Window
    {
        Grid grid1;
        public MainWindow()
        {
            InitializeComponent();
            int cellCount = 14;
            int numCols = 3;
            int numRows = (cellCount + 1) / numCols;
            grid1 = new Grid();
            
            this.AddChild(grid1);
            for(int i=0; i<numCols; ++i)
                this.grid1.ColumnDefinitions.Add(new ColumnDefinition());
            for (int i = 0; i < numRows; ++i)
                this.grid1.RowDefinitions.Add(new RowDefinition());
            foreach (var g in this.grid1.RowDefinitions)
            {
                g.Height = new GridLength(100);
            }
            foreach (var g in grid1.ColumnDefinitions)
            {
                g.Width = new GridLength(100);
            }
            for(int i=0; i<cellCount; ++i)
            {
                int idx = grid1.Children.Add(new Label());
                Label x = grid1.Children[idx] as Label;
                x.Content = "Cell " + i;
                x.SetValue(Grid.RowProperty, i/numCols);
                x.SetValue(Grid.ColumnProperty, i % numCols);
            }
        }
    }
