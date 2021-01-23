    public abstract class DataTableDictionary<T> : ContentPresenter where T : DataTableDictionary<T>
    {
        #region Dependency Properties
        public static readonly DependencyProperty KeyProperty = DependencyProperty.Register("Key", typeof(object), typeof(DataTableDictionary<T>), new PropertyMetadata(null, new PropertyChangedCallback(OnKeyChanged)));
        public static readonly DependencyProperty RowProperty = DependencyProperty.Register("Row", typeof(DataRowView), typeof(DataTableDictionary<T>), new PropertyMetadata(null, new PropertyChangedCallback(OnRowChanged)));
        public static readonly DependencyProperty ListItemsProperty = DependencyProperty.Register("ListItems", typeof(DataView), typeof(DataTableDictionary<T>), new PropertyMetadata(null));
        public static readonly DependencyProperty IndexedViewProperty = DependencyProperty.Register("IndexedView", typeof(DataView), typeof(DataTableDictionary<T>), new PropertyMetadata(null));
        #endregion Dependency Properties
        #region Private Members
        private static DataTable _SourceList = null;
        private static DataView _ListItems = null;
        private static DataView _IndexedView = null;
        private static readonly Binding BindingToRow;
        private static bool cachedViews = false;
        private bool m_isBeingChanged;
        #endregion Private Members
        #region Virtual Properties
        protected abstract DataTable table { get; }
        protected abstract string indexKeyField { get; }
        #endregion Virtual Properties
        #region Public Properties
        public DataView ListItems
        {
            get { return this.GetValue(ListItemsProperty) as DataView; }
            set { this.SetValue(ListItemsProperty, value); }
        }
        public DataView IndexedView
        {
            get { return this.GetValue(IndexedViewProperty) as DataView; }
            set { this.SetValue(IndexedViewProperty, value); }
        }
        public DataRowView Row
        {
            get { return this.GetValue(RowProperty) as DataRowView; }
            set { this.SetValue(RowProperty, value); }
        }
        public object Key
        {
            get { return this.GetValue(KeyProperty); }
            set { this.SetValue(KeyProperty, value); }
        }
        #endregion Public Properties
        #region Constructors
        static DataTableDictionary()
        {
            DataTableDictionary<T>.BindingToRow = new Binding();
            DataTableDictionary<T>.BindingToRow.Mode = BindingMode.OneWay;
            DataTableDictionary<T>.BindingToRow.Path = new PropertyPath(DataTableDictionary<T>.RowProperty);
            DataTableDictionary<T>.BindingToRow.RelativeSource = new RelativeSource(RelativeSourceMode.Self);
        }
        public DataTableDictionary()
        {
            ConstructDictionary();
            this.SetBinding(DataTableDictionary<T>.ContentProperty, DataTableDictionary<T>.BindingToRow);
        }
        #endregion Constructors
        #region Private Methods
        private bool ConstructDictionary()
        {            
            if( cachedViews == false )
            {
                _SourceList = table;
                if( _SourceList == null )
                {   //The application isn't loaded yet, we'll have to defer constructing this dictionary until it's used.
                    return false;
                }
                _SourceList = _SourceList.Copy(); //Copy the table so if the base table is modified externally we aren't affected.
                _ListItems = _SourceList.DefaultView;
                _IndexedView = CreateIndexedView(_SourceList, indexKeyField);
                cachedViews = true;
            }
            ListItems = _ListItems;
            IndexedView = _IndexedView;
            return true;
        }
        private DataView CreateIndexedView(DataTable table, string indexKey)
        {
            // Create a data view sorted by ID ( keyField ) to quickly find a row.
            DataView dataView = new DataView(table);
            dataView.Sort = indexKey;
            dataView.ApplyDefaultSort = true;
            return dataView;
        }
        #endregion Private Methods
        #region Static Event Handlers
        private static void OnKeyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // When the Key changes, try to find the data row that has the new key.
            // If it is not found, return null.
            DataTableDictionary<T> dataTableDictionary = sender as DataTableDictionary<T>;
            
            if( dataTableDictionary.m_isBeingChanged ) return; //Avoid Reentry
            dataTableDictionary.m_isBeingChanged = true;
            try
            {
                if( dataTableDictionary.IndexedView == null ) //We had to defer loading.
                    if( !dataTableDictionary.ConstructDictionary() )
                        return; //throw new Exception("Dataview is null. Check to make sure that all Reference tables are loaded.");
                DataRowView[] result = _IndexedView.FindRows(dataTableDictionary.Key);
                DataRowView dataRow = result.Length > 0 ? result[0] : null;
                //Sometimes a null key is valid - but sometimes it's just xceed being dumb - so we only skip the following step if it wasn't xceed.
                if( dataRow == null && dataTableDictionary.Key != null )
                {
                    //The entry was not in the DataView, so we will add it to the underlying table so that it is not nullified. Treaty validation will take care of notifying the user.
                    DataRow newRow = _SourceList.NewRow();
                    //DataRowView newRow = _IndexedView.AddNew();
                    int keyIndex = _SourceList.Columns.IndexOf(dataTableDictionary.indexKeyField);
                    for( int i = 0; i < _SourceList.Columns.Count; i++ )
                    {
                        if( i == keyIndex )
                        {
                            newRow[i] = dataTableDictionary.Key;
                        }
                        else if( _SourceList.Columns[i].DataType == typeof(String) )
                        {
                            newRow[i] = "(Unrecognized Code: '" + (dataTableDictionary.Key == null ? "NULL" : dataTableDictionary.Key) + "')";
                        }
                    }
                    newRow.EndEdit();
                    _SourceList.Rows.InsertAt(newRow, 0);
                    dataRow = _IndexedView.FindRows(dataTableDictionary.Key)[0];
                }
                dataTableDictionary.Row = dataRow;
            }
            catch (Exception ex)
            {
                throw new Exception("Unknow error in DataTableDictionary.OnKeyChanged.", ex);
            }
            finally
            {
                dataTableDictionary.m_isBeingChanged = false;
            }
        }
        private static void OnRowChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // When the Key changes, try to find the data row that has the new key.
            // If it is not found, return null.
            DataTableDictionary<T> dataTableDictionary = sender as DataTableDictionary<T>;
            if( dataTableDictionary.m_isBeingChanged ) return; //Avoid Reentry
            dataTableDictionary.m_isBeingChanged = true;
            try
            {
                if( dataTableDictionary.Row == null )
                {
                    dataTableDictionary.Key = null;
                }
                else
                {
                    dataTableDictionary.Key = dataTableDictionary.Row[dataTableDictionary.indexKeyField];
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unknow error in DataTableDictionary.OnRowChanged.", ex);
            }
            finally
            {
                dataTableDictionary.m_isBeingChanged = false;
            }
        }
        #endregion Static Event Handlers
    }
