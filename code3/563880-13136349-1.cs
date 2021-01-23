    var deser = new Deserialised(new Result());
    dynamic result = deser.GetObject(doc());
    var deser2 = new Deserialised(new Result2());
    dynamic result2 = deser.GetObject(doc());
    Console.Writeline(result.status);
    Console.Writeline(result2.status);
