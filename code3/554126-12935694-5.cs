    public static class Visual_ExtensionMethods
    {
        public static T FindDescendant<T>(this Visual @this, Predicate<T> predicate = null) where T : Visual
        {
            return @this.FindDescendant(v => v is T && (predicate == null || predicate((T)v))) as T;
        }
        public static Visual FindDescendant(this Visual @this, Predicate<Visual> predicate)
        {
            if (@this == null)
                return null;
            var frameworkElement = @this as FrameworkElement;
            if (frameworkElement != null)
            {
                frameworkElement.ApplyTemplate();
            }
            Visual child = null;
            for (int i = 0, count = VisualTreeHelper.GetChildrenCount(@this); i < count; i++)
            {
                child = VisualTreeHelper.GetChild(@this, i) as Visual;
                if (predicate(child))
                    return child;
                child = child.FindDescendant(predicate);
                if (child != null)
                    return child;
            }
            return child;
        }
    }
    public class GridAdorner : Adorner
    {
        public GridAdorner(MyDataGrid dataGrid)
            : base(dataGrid)
        {
            dataGrid.LayoutUpdated += new EventHandler(dataGrid_LayoutUpdated);
        }
        void dataGrid_LayoutUpdated(object sender, EventArgs e)
        {
            InvalidateVisual();
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            var myDataGrid = AdornedElement as MyDataGrid;
            if (myDataGrid == null)
                throw new InvalidOperationException();
            // Draw Horizontal lines
            var lastRowBottomOffset = myDataGrid.LastRowBottomOffset;
            var remainingSpace = myDataGrid.RenderSize.Height - lastRowBottomOffset;
            var placeHolderRowHeight = myDataGrid.PlaceHolderRowHeight;
            var lineNumber = (int)(Math.Floor(remainingSpace / placeHolderRowHeight));
            for (int i = 1; i <= lineNumber; i++)
            {
                Rect rectangle = new Rect(new Size(base.RenderSize.Width, 1)) { Y = lastRowBottomOffset + (i * placeHolderRowHeight) };
                drawingContext.DrawRectangle(Brushes.Black, null, rectangle);
            }
            // Draw vertical lines
            var reorderedColumns = myDataGrid.Columns.OrderBy(c => c.DisplayIndex);
            double verticalLineOffset = - myDataGrid.ScrollViewer.HorizontalOffset;
            foreach (var column in reorderedColumns)
            {
                verticalLineOffset += column.ActualWidth;
                Rect rectangle = new Rect(new Size(1, Math.Max(0, remainingSpace))) { X = verticalLineOffset, Y = lastRowBottomOffset };
                drawingContext.DrawRectangle(Brushes.Black, null, rectangle);
            }
        }
    }
    public class MyDataGrid : DataGrid
    {
        public MyDataGrid()
        {
            Background = Brushes.White;
            Loaded += new RoutedEventHandler(MyDataGrid_Loaded);
            PlaceHolderRowHeight = 20.0D; // random value, can be changed
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
        }
        private static void MyDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var dataGrid = sender as MyDataGrid;
            if (dataGrid == null)
                throw new InvalidOperationException();
            // Add the adorner that will be responsible for drawing grid lines
            var adornerLayer = AdornerLayer.GetAdornerLayer(dataGrid);
            if (adornerLayer != null)
            {
                adornerLayer.Add(new GridAdorner(dataGrid));
            }
            // Find DataGridRowsPresenter and set alignment to top to easily retrieve last row vertical offset
            dataGrid.DataGridRowsPresenter.VerticalAlignment = System.Windows.VerticalAlignment.Top;
        }
        public double PlaceHolderRowHeight
        {
            get;
            set;
        }
        public double LastRowBottomOffset
        {
            get
            {
                return DataGridColumnHeadersPresenter.RenderSize.Height + DataGridRowsPresenter.RenderSize.Height;
            }
        }
        public DataGridColumnHeadersPresenter DataGridColumnHeadersPresenter
        {
            get
            {
                if (dataGridColumnHeadersPresenter == null)
                {
                    dataGridColumnHeadersPresenter = this.FindDescendant<DataGridColumnHeadersPresenter>();
                    if (dataGridColumnHeadersPresenter == null)
                        throw new InvalidOperationException();
                }
                return dataGridColumnHeadersPresenter;
            }
        }
        public DataGridRowsPresenter DataGridRowsPresenter
        {
            get
            {
                if (dataGridRowsPresenter == null)
                {
                    dataGridRowsPresenter = this.FindDescendant<DataGridRowsPresenter>();
                    if (dataGridRowsPresenter == null)
                        throw new InvalidOperationException();
                }
                return dataGridRowsPresenter;
            }
        }
        public ScrollViewer ScrollViewer
        {
            get
            {
                if (scrollViewer == null)
                {
                    scrollViewer = this.FindDescendant<ScrollViewer>();
                    if (scrollViewer == null)
                        throw new InvalidOperationException();
                }
                return scrollViewer;
            }
        }
        private DataGridRowsPresenter dataGridRowsPresenter;
        private DataGridColumnHeadersPresenter dataGridColumnHeadersPresenter;
        private ScrollViewer scrollViewer;
    }
