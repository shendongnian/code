    public class MyDummyClass<T>
    {
        public MyDummyClass(Expression<Func<T, object>> expression)
        {
            NewArrayExpression array = expression.Body as NewArrayExpression;
            foreach( object obj in ( IEnumerable<object> )( array.Expressions ) )
            {
                Debug.Write( obj.ToString() );
            }
        }
    }
