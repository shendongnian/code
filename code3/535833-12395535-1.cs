    var accessor = TypeAccessor.Create(typeof(T)); 
    string propName = // something known only at runtime 
    while( /* some loop of data */ ) {
        var obj = new T();
        foreach(var col in cols) {
            string propName = // ...
            object cellValue = // ...
            accessor[obj, propName] = cellValue;
        }
        yield return obj;
    }
