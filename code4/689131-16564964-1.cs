    const decimal originalDecimal = 1.6641007661819458m;
    using (var memoryStream = new MemoryStream())
    {
        var obj = new DecimalWrapper { Value = originalDecimal };
        Serializer.Serialize(memoryStream, originalDecimal);
        memoryStream.Position = 0;
        var obj2 = Serializer.Deserialize<MyDecimalWrapper>(memoryStream);
        Console.WriteLine("{0}, {1}, {2}",
            obj2.Value.Lo, obj2.Value.Hi, obj2.Value.SignScale);
        memoryStream.SetLength(0);
        Serializer.Serialize(memoryStream, obj2);
        memoryStream.Position = 0;
        var obj3 = Serializer.Deserialize<DecimalWrapper>(memoryStream);
        bool eq = obj3.Value == obj.Value; // True
    }
