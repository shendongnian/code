    public abstract class Column { 
      public abstract object ValueUntyped { get; }
    }
    
    public abstract class Column<T> : Column {
      public T Value { get; set; }
      public override object ValueUntyped { get { return Value; } }
    }
    
    ...
    
    IList<Column> list = new List<Column>();
    list.Add(new DateColumn());
    list.Add(new NumberColumn());
