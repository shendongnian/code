        private void scrollViewer1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SizeGrid();
        }
        private void AddColumn_Button_Click(object sender, RoutedEventArgs e)
        {
            ColumnDefinition gridColN = new ColumnDefinition();
            grid1.ColumnDefinitions.Add(gridColN);
            SizeGrid();
        }
        private void AddRow_Button_Click(object sender, RoutedEventArgs e)
        {
            RowDefinition row = new RowDefinition();
            grid1.RowDefinitions.Add(row);
            SizeGrid();
        }
        private void SizeGrid()
        {
            grid1.Width = (scrollViewer1.ViewportWidth / 3) * grid1.ColumnDefinitions.Count;
            grid1.Height = (scrollViewer1.ViewportHeight / 2) * grid1.RowDefinitions.Count;        
        }
