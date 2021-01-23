    public class AjaxTableColumn<T>
    {
        public Func<T, HelperResult> Th { get; set; }
        public Func<T, HelperResult> Td { get; set; }
        
        public Expression KeySelector { get; set; }     // typ: Expression<Func<T,?>>, typicky neco jako: (T t) => t.Key
        public Type KeyType { get; set; }
        public OrderDataDelegate OrderData { get; set; }
        public delegate IQueryable<T> OrderDataDelegate(IQueryable<T> data, bool asc);
        
    }
