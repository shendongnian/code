    	public class ConfigToDynamicGridViewConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			var config = value as ColumnConfig;
			if (config != null) {
				var grdiView = new GridView();
				foreach (var column in config.Columns) {
					bool cc = !string.IsNullOrEmpty(column.ContentControlDataField);
					var binding = new Binding(cc ? column.ContentControlDataField : column.TextDataField);
					if (cc) {
						var template = new DataTemplate();
						var fact = new FrameworkElementFactory(typeof(ContentControl));
						fact.SetBinding(ContentControl.ContentProperty, binding);
						template.VisualTree = fact;
						grdiView.Columns.Add(new GridViewColumn {Header = column.Header, CellTemplate = template});
					} else
						grdiView.Columns.Add(new GridViewColumn {Header = column.Header, DisplayMemberBinding = binding});
				}
				return grdiView;
			}
			return Binding.DoNothing;
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			throw new NotSupportedException();
		}
	}
	public class ColumnConfig {
		public IEnumerable<Column> Columns { get; set; }
	}
	public class Column {
		public string Header { get; set; }
		public string TextDataField { get; set; }
		public string ContentControlDataField { get; set; }
	}
