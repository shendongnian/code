    public class CustomDataGrid : DataGrid
    {
        public static readonly DependencyProperty CustomSelectedItemsProperty = DependencyProperty.Register(
			"CustomSelectedItems", typeof (List<object>), typeof (CustomDataGrid), 
			new PropertyMetadata(new List<object>()));
		public List<object> CustomSelectedItems
		{
			get { return (List<object>) GetValue(CustomSelectedItemsProperty); }
			set { SetValue(CustomSelectedItemsProperty, value);}
		}
		protected override void OnSelectionChanged(SelectionChangedEventArgs e)
		{
			foreach(var item in e.AddedItems)
				CustomSelectedItems.Add(item);
			foreach (var item in e.RemovedItems)
				CustomSelectedItems.Remove(item);
			base.OnSelectionChanged(e);
		}
	}
