    public async static Task<T> RequestValue<T>(object arg) {
        var t = typeof (T);
        if (!t.IsClass && (!t.IsGenericType || t.GetGenericTypeDefinition() != typeof(Nullable<>))) {
            throw new ArgumentException("T");
        }
        // Whatever
    }
