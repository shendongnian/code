        public LabelValueGrid()
            : base()
        {
            ColumnDefinitions.Add(new ColumnDefinition());
            ColumnDefinitions.Add(new ColumnDefinition());
            ColumnDefinitions[0].Width = new System.Windows.GridLength(1, System.Windows.GridUnitType.Auto);
            ColumnDefinitions[1].Width = new System.Windows.GridLength(1, System.Windows.GridUnitType.Star);
        }
        protected override void OnVisualChildrenChanged(System.Windows.DependencyObject visualAdded, System.Windows.DependencyObject visualRemoved)
        {
            base.OnVisualChildrenChanged(visualAdded, visualRemoved);
            int curRow = -1;
            int curCol = 1;
            RowDefinitions.Clear();
            if (Children != null)
                foreach (System.Windows.UIElement curChild in Children)
                {
                    if (curCol == 0)
                        curCol = 1;
                    else
                    {
                        curCol = 0;
                        curRow++;
                        RowDefinitions.Add(new RowDefinition() {Height = new System.Windows.GridLength(1, System.Windows.GridUnitType.Auto)});
                    }
                    Grid.SetRow(curChild, curRow);
                    Grid.SetColumn(curChild, curCol);
                }
            RowDefinitions.Add(new RowDefinition() {Height = new System.Windows.GridLength(1, System.Windows.GridUnitType.Star)});
        }
    }
