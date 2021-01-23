    var json = "[ [ [ \"JR10\", \"Test1\", 142, 199, 66 ], [ \"JR10\", \"Test2\", 142, 199, 66 ] ] ]";
    var serializer = new JavaScriptSerializer();
    var result = serializer.Deserialize<object[][][]>(json);
    Console.WriteLine(result[0][0][0]); // "JR10"
    Console.WriteLine(result[0][0][1]); // "Test1"
    Console.WriteLine(result[0][1][0]); // "JR10"
    Console.WriteLine(result[0][1][1]); // "Test2"
    ...
