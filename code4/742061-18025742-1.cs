    public GridViewColumn<TResult> Column<TColumn>(string HeaderText, TColumn decorator = null) where TColumn : class, IColumnDecorator
    {
        GridViewColumn<TResult> column = new GridViewColumn<TResult>();
        column.HeaderText = HeaderText;
        
         if(decorator == null)
         {
            column.Decorator = new DefaultColumnDecorator();
         }
         else
         {
            column.Decorator = decorator;  
         }     
    
        return column;
    }
