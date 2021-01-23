    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace YourNamespace
    {
        public partial class BindableGrid : UserControl
        {
            public static readonly DependencyProperty WidthsProperty =
                DependencyProperty.Register("Widths",
                                            typeof(ObservableCollection<int>),
                                            typeof(BindableGrid),
                                            new PropertyMetadata(Widths_Changed));
    
            public BindableGrid()
            {
                InitializeComponent();
            }
    
            public ObservableCollection<int> Widths
            {
                get { return (ObservableCollection<int>)GetValue(WidthsProperty); }
                set { SetValue(WidthsProperty, value); }
            }
    
            private static void Widths_Changed(DependencyObject obj,
                                               DependencyPropertyChangedEventArgs e)
            {
                var grid = obj as BindableGrid;
                if (grid != null)
                {
                    grid.OnWidthsChanged(e.OldValue as ObservableCollection<int>);
                }
            }
    
            private void OnWidthsChanged(ObservableCollection<int> oldValue)
            {
                if (oldValue != null)
                {
                    oldValue.CollectionChanged -= Widths_CollectionChanged;
                }
    
                if (Widths != null)
                {
                    Widths.CollectionChanged += Widths_CollectionChanged;
                }
    
                RecreateGrid();
            }
    
            private void Widths_CollectionChanged(object sender,
                                                  NotifyCollectionChangedEventArgs e)
            {
                // We'll just clear and recreate the entire grid each time
                // the collection changes.
                // Alternatively, you could use e.Action to determine what the
                // actual change was and apply that (e.g. add or delete a
                // single column definition). 
                RecreateGrid();
            }
    
            private void RecreateGrid()
            {
                // Recreate the column definitions.
                grid.ColumnDefinitions.Clear();
                foreach (int width in Widths)
                {
                    // Use new GridLength(1, GridUnitType.Star) for a "*" column.
                    var coldef = new ColumnDefinition() { Width = new GridLength(width) };
                    grid.ColumnDefinitions.Add(coldef);
                }
    
                // Now recreate the content of the grid.
                grid.Children.Clear();
                for (int i = 0; i < Widths.Count; ++i)
                {
                    int width = Widths[i];
                    var textblock = new TextBlock() { Text = width.ToString() };
                    Grid.SetColumn(textblock, i);
                    grid.Children.Add(textblock);
                }
            }
        }
    }
