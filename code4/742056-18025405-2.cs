    public GridViewColumn<T> Column<D>(String HeaderText) where D: IColumnDecorator, new()
    {
    	GridViewColumn<T> column = new GridViewColumn<T>();
    	column.HeaderText = HeaderText;
    	column.Decorator = new D();
    	return column;
    }
