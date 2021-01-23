    public GridViewColumn<T> Column<D>(String HeaderText, D decorator) where D: IColumnDecorator
    {
    	GridViewColumn<T> column = new GridViewColumn<T>();
    	column.HeaderText = HeaderText;
    	column.Decorator = decorator;
    	return column;
    }
    
    public GridViewColumn<DefaultColumnDecorator> Column(String headerText)
    {
    	return Column(headerText, new DefaultColumnDecorator());
    }
