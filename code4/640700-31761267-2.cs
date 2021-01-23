    public class Product
    {
        public List<dynamic> DynamicProperties { get; set; }
    }
    ...
    conn.Open();
    using (var reader = cmd.ExecuteReader())
    {
        var p = new Products();
        p.DynamicProperties = reader.AsDyamic().ToList();
        //or
        foreach (var item in reader.AsDynamic())
            yield return item;
    }
    // carry this extension method around
    public static IEnumerable<dynamic> AsDynamic(this IDataReader reader)
    {
        var names = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList();
        foreach (IDataRecord record in reader as IEnumerable)
        {
            var expando = new ExpandoObject() as IDictionary<string, object>;
            foreach (var name in names)
                expando[name] = record[name];
            yield return expando;
        }
    }
