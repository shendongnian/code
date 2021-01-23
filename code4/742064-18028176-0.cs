    public GridViewColumn<T> Column(string HeaderText, Func<IColumnDecorator> decoratorGenerator)
    {
      GridViewColumn<T> column = new GridViewColumn<T>();
      column.HeaderText = HeaderText;
      column.Decorator = decoratorGenerator != null ? decoratorGenerator()
        : new DefaultColumnDecorator() ;
      return column;
    }
