    using MyTuple = Tuple<Tuple<Argument, string>, Argument>;
    using MyTuple2 = Tuple<Argument, string>;
    
    public class MyClass {
    
        private MyTuple f(string e, List<Argument> valid) {
            var p = valid.Find( x => { return e.StartsWith( x.value ); } );
            if ( p == null )
               return new MyTuple( null, null );
            if ( p.flag )
               return new MyTuple( new MyTuple2( p, "" ), null );
            if ( p.separator.Equals(" ") && p.value.Length == e.Length )
                return new MyTuple( null, p );
            var si = e.IndexOf(p.separator);
            if ( si != p.value.Length )
                return MyTuple( null, null );
            return new MyTuple( new MyTuple2( p, 
                e.Substring( si + p.separator.Length ) ), null );
        }
    }
