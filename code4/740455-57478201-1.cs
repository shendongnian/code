    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace SGRE.WOS.Common.UI
    {
        public class DataGridColumnsBehavior
        {
            public static readonly DependencyProperty BindableColumnsProperty = DependencyProperty.RegisterAttached("BindableColumns", typeof(ObservableCollection<DataGridColumn>), typeof(DataGridColumnsBehavior), new UIPropertyMetadata(null, BindableColumnsPropertyChanged));
            /// <summary>Collection to store collection change handlers - to be able to unsubscribe later.</summary>
            private static readonly Dictionary<DataGrid, NotifyCollectionChangedEventHandler> _handlers;
    
            static DataGridColumnsBehavior()
            {
                _handlers = new Dictionary<DataGrid, NotifyCollectionChangedEventHandler>();
            }
            private static void BindableColumnsPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
            {
                if (!(source is DataGrid dataGrid)) return;
                if (e.OldValue is ObservableCollection<DataGridColumn> oldColumns)
                {
                    // Remove all columns.
                    dataGrid.Columns.Clear();
    
                    // Unsubscribe from old collection.
                    if (_handlers.TryGetValue(dataGrid, out var h))
                    {
                        oldColumns.CollectionChanged -= h;
                        _handlers.Remove(dataGrid);
                    }
                }
    
                var newColumns = e.NewValue as ObservableCollection<DataGridColumn>;
                dataGrid.Columns.Clear();
                if (newColumns != null)
                {
                    // Add columns from this source.
                    foreach (var column in newColumns)
                        if (column != null)
                        {
                            var dg = (DataGrid)column.GetType().GetProperty("DataGridOwner", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(column, null);
                            dg?.Columns.Clear();
                            dataGrid.Columns.Add(column);
                        }
    
    
                    // Subscribe to future changes.
                    NotifyCollectionChangedEventHandler h = (_, ne) => OnCollectionChanged(ne, dataGrid);
                    _handlers[dataGrid] = h;
                    newColumns.CollectionChanged += h;
                }
            }
    
            private static void OnCollectionChanged(NotifyCollectionChangedEventArgs ne, DataGrid dataGrid)
            {
                switch (ne.Action)
                {
                    case NotifyCollectionChangedAction.Reset:
                        dataGrid.Columns.Clear();
                        if (ne.NewItems != null && ne.NewItems.Count > 0)
                            foreach (DataGridColumn column in ne.NewItems)
                                dataGrid.Columns.Add(column);
                        break;
                    case NotifyCollectionChangedAction.Add:
                        foreach (DataGridColumn column in ne.NewItems)
                            dataGrid.Columns.Add(column);
                        break;
                    case NotifyCollectionChangedAction.Move:
                        dataGrid.Columns.Move(ne.OldStartingIndex, ne.NewStartingIndex);
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        foreach (DataGridColumn column in ne.OldItems)
                            dataGrid.Columns.Remove(column);
                        break;
                    case NotifyCollectionChangedAction.Replace:
                        dataGrid.Columns[ne.NewStartingIndex] = ne.NewItems[0] as DataGridColumn;
                        break;
                }
            }
            public static void SetBindableColumns(DependencyObject element, ObservableCollection<DataGridColumn> value)
            {
                element.SetValue(BindableColumnsProperty, value);
            }
            public static ObservableCollection<DataGridColumn> GetBindableColumns(DependencyObject element)
            {
                return (ObservableCollection<DataGridColumn>)element.GetValue(BindableColumnsProperty);
            }
        }
    }
