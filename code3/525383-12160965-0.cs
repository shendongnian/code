			Binding columnBinding = new Binding("CanConnect");
			Binding styleBinding = new Binding("CanConnect") { Converter = new IsConnectedConverter()};	
			Style st = new Style(typeof(DataGridCell));
			st.Setters.Add(new Setter(Control.BackgroundProperty, styleBinding));
			column.CellStyle = st;
			column.Binding = columnBinding;
			dataGrid.Columns.Add(column);
