    double GetHHSum<T>(T x) where T : class
    {
       double result = 0;
       var properties = typeof(T).GetProperties();
       foreach (var property in properties)
       {
           if (property.Name.StartsWith("HH"))
              sum += Convert.ToSingle(property.GetValue(x)).GetValueOrDefault();
       }
       return result;
    }
