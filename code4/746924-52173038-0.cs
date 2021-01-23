    public class DataGridColumnCollectionBehavior
    {
        private object columnsSource;
        private DataGrid dataGrid;
        public DataGridColumnCollectionBehavior(DataGrid dataGrid)
        {
            this.dataGrid = dataGrid;
        }
        public object ColumnsSource
        {
            get { return this.columnsSource; }
            set
            {
                object oldValue = this.columnsSource;
                this.columnsSource = value;
                this.ColumnsSourceChanged(oldValue, this.columnsSource);
            }
        }
        public string DisplayMemberFormatMember { get; set; }
        public string DisplayMemberMember { get; set; }
        public string FontWeightBindingMember { get; set; }
        public string FontWeightMember { get; set; }
        public string HeaderTextMember { get; set; }
        public string IsEditableMember { get; set; }
        public string SortMember { get; set; }
        public string TextAlignmentMember { get; set; }
        public string TextColourMember { get; set; }
        public string WidthMember { get; set; }
        private void AddHandlers(ICollectionView collectionView)
        {
            collectionView.CollectionChanged += this.ColumnsSource_CollectionChanged;
        }
        private void ColumnsSource_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ICollectionView view = sender as ICollectionView;
            if (this.dataGrid == null)
            {
                return;
            }
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    for (int i = 0; i < e.NewItems.Count; i++)
                    {
                        DataGridColumn column = CreateColumn(e.NewItems[i]);
                        dataGrid.Columns.Insert(e.NewStartingIndex + i, column);
                    }
                    break;
                case NotifyCollectionChangedAction.Move:
                    List<DataGridColumn> columns = new List<DataGridColumn>();
                    for (int i = 0; i < e.OldItems.Count; i++)
                    {
                        DataGridColumn column = dataGrid.Columns[e.OldStartingIndex + i];
                        columns.Add(column);
                    }
                    for (int i = 0; i < e.NewItems.Count; i++)
                    {
                        DataGridColumn column = columns[i];
                        dataGrid.Columns.Insert(e.NewStartingIndex + i, column);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    for (int i = 0; i < e.OldItems.Count; i++)
                    {
                        dataGrid.Columns.RemoveAt(e.OldStartingIndex);
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    for (int i = 0; i < e.NewItems.Count; i++)
                    {
                        DataGridColumn column = CreateColumn(e.NewItems[i]);
                        dataGrid.Columns[e.NewStartingIndex + i] = column;
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    dataGrid.Columns.Clear();
                    CreateColumns(sender as ICollectionView);
                    break;
                default:
                    break;
            }
        }
        private void ColumnsSourceChanged(object oldValue, object newValue)
        {
            if (this.dataGrid != null)
            {
                dataGrid.Columns.Clear();
                if (oldValue != null)
                {
                    ICollectionView view = CollectionViewSource.GetDefaultView(oldValue);
                    if (view != null)
                    {
                        this.RemoveHandlers(view);
                    }
                }
                if (newValue != null)
                {
                    ICollectionView view = CollectionViewSource.GetDefaultView(newValue);
                    if (view != null)
                    {
                        this.AddHandlers(view);
                        this.CreateColumns(view);
                    }
                }
            }
        }
        private DataGridColumn CreateColumn(object columnSource)
        {
            DataGridColumn column = new DataGridTemplateColumn();
            var textBlockFactory = new FrameworkElementFactory(typeof(TextBlock));
            ((DataGridTemplateColumn)column).CellTemplate = new DataTemplate { VisualTree = textBlockFactory };
            textBlockFactory.SetValue(TextBlock.MarginProperty, new Thickness(3));
            if (!string.IsNullOrWhiteSpace(this.FontWeightBindingMember))
            {
                string propertyName = GetPropertyValue(columnSource, this.FontWeightBindingMember) as string;
                textBlockFactory.SetBinding(TextBlock.FontWeightProperty, new Binding(propertyName));
            }
            else if (!string.IsNullOrWhiteSpace(this.FontWeightMember))
            {
                textBlockFactory.SetValue(TextBlock.FontWeightProperty, (FontWeight)GetPropertyValue(columnSource, this.FontWeightMember));
            }
            if (!string.IsNullOrWhiteSpace(this.SortMember))
            {
                column.SortMemberPath = GetPropertyValue(columnSource, this.SortMember) as string;
            }
            if (!string.IsNullOrEmpty(this.DisplayMemberMember))
            {
                string propertyName = GetPropertyValue(columnSource, this.DisplayMemberMember) as string;
                string format = null;
                if (!string.IsNullOrEmpty(this.DisplayMemberFormatMember))
                {
                    format = GetPropertyValue(columnSource, this.DisplayMemberFormatMember) as string;
                }
                if (string.IsNullOrEmpty(format))
                {
                    format = "{0}";
                }
                textBlockFactory.SetBinding(TextBlock.TextProperty, new Binding(propertyName) { StringFormat = format });
                // If there is no sort member defined default to the display member.
                if (string.IsNullOrWhiteSpace(column.SortMemberPath))
                {
                    column.SortMemberPath = propertyName;
                }
            }
            if (!string.IsNullOrWhiteSpace(this.TextAlignmentMember))
            {
                textBlockFactory.SetValue(TextBlock.TextAlignmentProperty, GetPropertyValue(columnSource, this.TextAlignmentMember));
            }
            if (!string.IsNullOrEmpty(this.HeaderTextMember))
            {
                column.Header = GetPropertyValue(columnSource, this.HeaderTextMember);
            }
            if (!string.IsNullOrWhiteSpace(this.TextColourMember))
            {
                string propertyName = GetPropertyValue(columnSource, this.TextColourMember) as string;
                textBlockFactory.SetBinding(TextBlock.ForegroundProperty, new Binding(propertyName));
            }
            if (!string.IsNullOrEmpty(this.WidthMember))
            {
                double width = (double)GetPropertyValue(columnSource, this.WidthMember);
                column.Width = width;
            }
            return column;
        }
        private void CreateColumns(ICollectionView collectionView)
        {
            foreach (object item in collectionView)
            {
                DataGridColumn column = this.CreateColumn(item);
                this.dataGrid.Columns.Add(column);
            }
        }
        private object GetPropertyValue(object obj, string propertyName)
        {
            object returnVal = null;
            if (obj != null)
            {
                PropertyInfo prop = obj.GetType().GetProperty(propertyName);
                if (prop != null)
                {
                    returnVal = prop.GetValue(obj, null);
                }
            }
            return returnVal;
        }
        private void RemoveHandlers(ICollectionView collectionView)
        {
            collectionView.CollectionChanged -= this.ColumnsSource_CollectionChanged;
        }
    }
