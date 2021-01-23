        public static  List<UIElement> GetGridCellChildren(this Grid grid, int row, int col)
        {
            return grid.Children.Cast<UIElement>().Where(
                                x => Grid.GetRow(x) == row && Grid.GetColumn(x) == col).ToList();
        }
        public static void ReadjustRows(this Grid myGrid, int row)
        {
            if (row < myGrid.RowDefinitions.Count)
            {
                for (int i = row + 1; i <= myGrid.RowDefinitions.Count; i++)
                {
                    for (int j = 0; j < myGrid.ColumnDefinitions.Count; j++)
                    {
                        List<UIElement> children = myGrid.GetGridCellChildren(i, j);
                        foreach(UIElement uie in children)
                        {
                            Grid.SetRow(uie,i - 1);
                        }
                    }
                }
            }
        }
