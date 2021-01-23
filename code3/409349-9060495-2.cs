    const char DELIMITER = '.';
    var source = "Class1.StructA.StructB.StructC.FieldA";
    var result = new List<string>();
    for (int i = 0; i < source.Length; i++)
    {
        if (source[i] == DELIMITER)
        {
            result.Add(source.Substring(0, i));
        }
    }
    result.Add(source); // assuming there is no trailing delimiter
