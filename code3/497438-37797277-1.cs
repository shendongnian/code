    public static class ListDataView
    {
    	public static IList Create(object dataSource, string dataMember, Func<PropertyDescriptor, PropertyDescriptor> propertyMapper)
    	{
    		var source = (IList)ListBindingHelper.GetList(dataSource, dataMember);
    		if (source == null) return null;
    		if (source is IBindingListView) return new BindingListView((IBindingListView)source, propertyMapper);
    		if (source is IBindingList) return new BindingList((IBindingList)source, propertyMapper);
    		return new List(source, propertyMapper);
    	}
    
    	private class List : IList, ITypedList
    	{
    		private readonly IList source;
    		private readonly Func<PropertyDescriptor, PropertyDescriptor> propertyMapper;
    		public List(IList source, Func<PropertyDescriptor, PropertyDescriptor> propertyMapper) { this.source = source; this.propertyMapper = propertyMapper; }
    		// IList
    		public object this[int index] { get { return source[index]; } set { source[index] = value; } }
    		public int Count { get { return source.Count; } }
    		public bool IsFixedSize { get { return source.IsFixedSize; } }
    		public bool IsReadOnly { get { return source.IsReadOnly; } }
    		public bool IsSynchronized { get { return source.IsSynchronized; } }
    		public object SyncRoot { get { return source.SyncRoot; } }
    		public int Add(object value) { return source.Add(value); }
    		public void Clear() { source.Clear(); }
    		public bool Contains(object value) { return source.Contains(value); }
    		public void CopyTo(Array array, int index) { source.CopyTo(array, index); }
    		public IEnumerator GetEnumerator() { return source.GetEnumerator(); }
    		public int IndexOf(object value) { return source.IndexOf(value); }
    		public void Insert(int index, object value) { source.Insert(index, value); }
    		public void Remove(object value) { source.Remove(value); }
    		public void RemoveAt(int index) { source.RemoveAt(index); }
    		// ITypedList
    		public string GetListName(PropertyDescriptor[] listAccessors) { return ListBindingHelper.GetListName(source, listAccessors); }
    		public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
    		{
    			var properties = ListBindingHelper.GetListItemProperties(source, listAccessors);
    			if (propertyMapper != null)
    				properties = new PropertyDescriptorCollection(properties.Cast<PropertyDescriptor>()
    					.Select(propertyMapper).Where(p => p != null).ToArray());
    			return properties;
    		}
    	}
    
    	private class BindingList : List, IBindingList
    	{
    		private IBindingList source;
    		public BindingList(IBindingList source, Func<PropertyDescriptor, PropertyDescriptor> propertyMapper) : base(source, propertyMapper) { this.source = source; }
    		private ListChangedEventHandler listChanged;
    		public event ListChangedEventHandler ListChanged
    		{
    			add
    			{
    				var oldHandler = listChanged;
    				if ((listChanged = oldHandler + value) != null && oldHandler == null)
    					source.ListChanged += OnListChanged;
    			}
    			remove
    			{
    				var oldHandler = listChanged;
    				if ((listChanged = oldHandler - value) == null && oldHandler != null)
    					source.ListChanged -= OnListChanged;
    			}
    		}
    		private void OnListChanged(object sender, ListChangedEventArgs e)
    		{
    			var handler = listChanged;
    			if (handler != null)
    				handler(this, e);
    		}
    		public bool AllowNew { get { return source.AllowNew; } }
    		public bool AllowEdit { get { return source.AllowEdit; } }
    		public bool AllowRemove { get { return source.AllowRemove; } }
    		public bool SupportsChangeNotification { get { return source.SupportsChangeNotification; } }
    		public bool SupportsSearching { get { return source.SupportsSearching; } }
    		public bool SupportsSorting { get { return source.SupportsSorting; } }
    		public bool IsSorted { get { return source.IsSorted; } }
    		public PropertyDescriptor SortProperty { get { return source.SortProperty; } }
    		public ListSortDirection SortDirection { get { return source.SortDirection; } }
    		public object AddNew() { return source.AddNew(); }
    		public void AddIndex(PropertyDescriptor property) { source.AddIndex(property); }
    		public void ApplySort(PropertyDescriptor property, ListSortDirection direction) { source.ApplySort(property, direction); }
    		public int Find(PropertyDescriptor property, object key) { return source.Find(property, key); }
    		public void RemoveIndex(PropertyDescriptor property) { source.RemoveIndex(property); }
    		public void RemoveSort() { source.RemoveSort(); }
    	}
    
    	private class BindingListView : BindingList, IBindingListView
    	{
    		private IBindingListView source;
    		public BindingListView(IBindingListView source, Func<PropertyDescriptor, PropertyDescriptor> propertyMapper) : base(source, propertyMapper) { this.source = source; }
    		public string Filter { get { return source.Filter; } set { source.Filter = value; } }
    		public ListSortDescriptionCollection SortDescriptions { get { return source.SortDescriptions; } }
    		public bool SupportsAdvancedSorting { get { return source.SupportsAdvancedSorting; } }
    		public bool SupportsFiltering { get { return source.SupportsFiltering; } }
    		public void ApplySort(ListSortDescriptionCollection sorts) { source.ApplySort(sorts); }
    		public void RemoveFilter() { source.RemoveFilter(); }
    	}
    }
