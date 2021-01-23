    var exo = new ExpandoObject() as IDictionary<String, Object>;
    var nested1 = new ExpandoObject() as IDictionary<String, Object>;
    exo.Add("Nested1", nested1);
    nested1.Add("Nested2", "value");
    dynamic d = exo;
    Console.WriteLine(d.Nested1.Nested2); // Outputs "value"
