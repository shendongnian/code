    public GridViewColumn<TResult> Column<TColumn>(string HeaderText, TColumn decorator = null) where TColumn : IColumnDecorator, new()
    {
    	GridViewColumn<TResult> column = new GridViewColumn<TResult>();
    	column.HeaderText = HeaderText;
    	column.Decorator = decorator == null ? new DefaultColumnDecorator() : default(TColumn);
    
    	return column;
    }
