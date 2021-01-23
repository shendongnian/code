     public GridViewColumn<T> Column(String HeaderText, IColumnDecorator decorator) 
            {
                GridViewColumn<T> column = new GridViewColumn<T>();
                column.HeaderText = HeaderText;
                if(decorator ==null)
                {
                   column.Decorator = new DefaultColumnDecorator();
                }
                else{
                   column.Decorator = decorator;
                }
                return column;
            }
