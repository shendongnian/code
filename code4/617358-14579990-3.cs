    public interface IRowsBuilder
    {
        bool CanBuildFor(Type type);
        IEnumerable<Type> SupportedTypes { get; }
        ExcelRow BuildRow(object value);
    }
    
    public class RowsBuilder<T> : IRowsBuilder where T : Classification
    {
        Func<T, ExcelRow> _builder;
        
        public RowsBuilder(Func<T, ExcelRow> builder)
        {
            if(builder == null) throw new ArgumentNullException("builder");
    
            _builder = builder;
        }
    
        public bool CanBuildFor(Type type)
        {
            return type.IsSubclassOf(typeof(T));
        }
        public IEnumerable<Type> SupportedTypes
        {
            get { yield return typeof(T); }
        }
    
        public ExcelRow BuildRow(object value)
        {
            if(!CanBuildFor(value.GetType()))
                throw new ArgumentException();
    
            return _builder((T)value);
        }
    }
    public class ExcelMediaTypeFormatter : BufferedMediaTypeFormatter 
    {
        private readonly ILookup<Type, IRowsBuilder> _builder;
    
        public ExcelMediaTypeFormatter(IEnumerable<IRowsBuilder> builder)
        {
            _builder = builder.SelectMany(x => builder.SupportedTypes
                                                      .Select(y => new
                                                              {
                                                                  Type = y,
                                                                  Builder = x
                                                              }))
                              .ToLookup(x => x.Type, x => x.Builder); 
        }
    
        public override bool CanWriteType(Type type)
        {
            return type == typeof(IQueryable<Classification>) ||
                   type == typeof(Classification);
        }
    
        // ...
    
        public override void WriteToStream(Type type, object value,
                                           Stream writeStream, HttpContent content)
        {
    
            // ...
        
            List<Classification> rows;
            if(type == typeof(IQueryable<Classification>))
                rows = ((IQueryable<Classification>)value).ToList();
            else
                rows = new List<Classification> { (Classification)value };
    
            for (var r = 0; r < rows.Count; r++)
            {
                var value = rows.ElementAt(r);
                var builder = _builder[value.GetType()];
                var result = builder(value);
                // ...
            }
        }
    }
