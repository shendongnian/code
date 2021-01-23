    JsonSchemaGenerator js = new JsonSchemaGenerator();
    var schema = js.Generate(t);
    schema.Title = t.Name;
    using (StreamWriter fileWriter = File.CreateText(filePath))
    {
          fileWriter.WriteLine(schema);
    }
