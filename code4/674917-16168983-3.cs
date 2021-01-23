    var result = inputclass.Select(
                     input => (from str in metadata
                               join prop in input.GetType().GetProperties()
                               on str equals prop.Name
                               select new { Obj = input, Prop = str, Value = prop.GetValue(input, null) }))
                               .SelectMany(i => i)
                               .GroupBy(obj => obj.Obj);
    foreach (var obj in result)
    {
        Console.WriteLine(obj.Key);
        foreach (var prop in obj)
        {
            Console.WriteLine(prop.Prop + ":" + prop.Value);
        }
        Console.WriteLine();
     }
     Console.ReadKey();
