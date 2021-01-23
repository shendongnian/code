    public static string ToFooJson<T>(this FooCollection fooCollection)
    {
         return JsonConvert.SerializeObject(new
         {
             Bar = fooCollection.Bar,
             Collection = fooCollection
         });
    }
