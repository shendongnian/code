    public T GetFieldValue<T>(string fieldName) {
        var theTypeOfT = typeof(T);
    }
    // Call this using Nullable<T>:
    var someNullableInt = GetFieldValue<Nullable<T>>("foo");
