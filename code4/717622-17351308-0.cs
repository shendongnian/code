    Style s = new Style(typeof(DataGridColumnHeader));
    s.BasedOn = this.DataGrid_CardDetails.ColumnHeaderStyle;
    s.Setters.Add(new Setter(DataGridColumnHeader.FontSizeProperty, 26));
    
    this.DataGrid_CardDetails.ColumnHeaderStyle = s;
