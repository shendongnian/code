    List<dynamic> list = new List<dynamic>();
    list.Add(new { a = "Col1", b = "b" });
    list.Add(new { a = "Col2", b = "c" });
    list.Add(new { a = "Col1", b = "c" });
    string[] columns = new string[] { "Col1", "Col2" };
    foreach (string column in columns)
    {
        Console.WriteLine(column);
        //get unique value for column and add them to some collection 
        var select=list.Where((x) => { return x.a == column; }).Select(x=>x.b);
        select.ToList().ForEach((x) => { Console.WriteLine("{0}",x ); });
    }
    Console.Read();
