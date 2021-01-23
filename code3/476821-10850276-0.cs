    interface ITableColumn { }
    class SomeObject 
    {
        public int MyProperty { get; set; }
    }
    class Column<TModel>
    {
        public ITableColumn Expression<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            // just a stub
            return null;
        }
    }
