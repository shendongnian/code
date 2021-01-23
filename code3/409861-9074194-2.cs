TestEnum input = TestEnum.One | TestEnum.Two;
TestEnum[] TestEnumValues = (TestEnum[])Enum.GetValues(typeof(TestEnum));
string[] TestEnumNames = Enum.GetNames(typeof(TestEnum));
var result = new List<string>();
TestEnumValues.ToList().ForEach(v => 
    {
        if ((input & v) != 0) 
        { 
            var index = Array.IndexOf(TestEnumValues, v);
            result.Add(TestEnumNames[index]); 
        }
    });
Console.WriteLine(string.Join(", ", result));
