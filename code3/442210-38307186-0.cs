    Style stylecell = new Style(typeof(DataGridCell));
    Binding descriptionbinding = new Binding("SRNO") { StringFormat = "{0}" };
    
    stylecell.Setters.Add(newSetter(ToolTipService.ToolTipProperty,descriptionbinding));
    gridItem.Columns[0].CellStyle = stylecell;
