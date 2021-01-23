    class MyObject<T>
    {
        // This is a String Indexer Expression, used to define the string indexer when the object is in a collection of MyObjects 
        public Expression<Func<T, string, bool>> StringIndexExpression { get; private set;} 
     
     
        // I use this method in Set StringIndexExpression and T is a subtype of MyObject 
        protected void DefineStringIndexer<T>(Expression<T, string, bool>> expresson) 
            where T : MyObject<T> // Think you need this constraint to also have the generic param
        { 
            StringIndexExpression = expression; 
        } 
    }
