    public class ArrangeGrid : Grid
    {
        public ArrangeGrid()
        {
            ColumnDefinitions.Add(new ColumnDefinition());
            ColumnDefinitions.Add(new ColumnDefinition());
            ColumnDefinitions.Add(new ColumnDefinition());
        }
        public static DependencyProperty GridCellProperty = DependencyProperty.RegisterAttached("GridCell", typeof(int), typeof(ArrangeGrid));
        public static void SetGridCell(UIElement element, int value)
        {
            element.SetValue(ArrangeGrid.GridCellProperty, value);
        }
        [AttachedPropertyBrowsableForChildren]
        public static int GetGridCell(UIElement element)
        {
            return (int)element.GetValue(ArrangeGrid.GridCellProperty);
        }
        protected override Size MeasureOverride(Size constraint)
        {
            RowDefinitions.Clear();
            int rowCount = this.Children.Count / 3;
            if (this.Children.Count % 3 != 0)
            {
                rowCount += 1;
            }
            while (RowDefinitions.Count < rowCount)
            {
                RowDefinitions.Add(new RowDefinition());
            }
            foreach (var child in this.Children)
            {
                int gridCell = ArrangeGrid.GetGridCell((UIElement)child);
                int gridRow = gridCell / 3;
                int gridCol = gridCell % 3;
                ((UIElement)child).SetValue(Grid.RowProperty, gridRow);
                ((UIElement)child).SetValue(Grid.ColumnProperty, gridCol);
            }
            return base.MeasureOverride(constraint);
        }
    }
