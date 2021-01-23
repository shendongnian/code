	public class CellViewModelToTagConverter : MarkupExtension, IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			var row = values[0] as MyRowViewModel;
			var cell = values[1] as DataGridCell;
			if (row != null && cell != null)
			{
				var column = cell.Column as DataGridColumn;
				if (column != null)
					cell.SetBinding(FrameworkElement.TagProperty, new Binding {
						Source = row[column.DataGridOwner.Columns.IndexOf(column)],
						BindsDirectlyToSource = true
					});
			}
			return DependencyProperty.UnsetValue;
		}
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return new CellViewModelToTagConverter();
		}
	}
