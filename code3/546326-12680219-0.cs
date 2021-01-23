    using (var input = File.OpenRead(path))
    using (var reader = new ProtoReader(input, RuntimeTypeModel.Default, null))
    {
        while (reader.ReadFieldHeader() > 0)
        {
            Console.WriteLine("offset {0}, field {1}, type {2}",
                reader.Position, reader.FieldNumber, reader.WireType);
            reader.SkipField();
        }
    }
