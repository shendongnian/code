    using MyTuple = Tuple<Tuple<Argument, string>, Argument>;
    
    public class MyClass {
    
        private MyTuple f(string e, List<Argument> valid) {
            var p = valid.Find( x => { return e.StartsWith( x.value ); } );
            if ( p == null )
               return new MyTuple( null, null );
            if ( p.flag )
               return new MyTuple( new Tuple<Argument, String>( p, "" ), null );
            if ( p.separator.Equals(" ") && p.value.Length == e.Length )
                return new MyTuple( null, p );
            var si = e.IndexOf(p.separator);
            if ( si != p.value.Length )
                return MyTuple( null, null );
            return new MyTuple( new Tuple<Argument, String>( p, 
                e.Substring( si + p.separator.Length ) ), null );
        }
    }
