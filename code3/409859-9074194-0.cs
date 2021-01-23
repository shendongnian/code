TestEnum input = TestEnum.One;
TestEnum[] TestEnumValues = (TestEnum[])Enum.GetValues(typeof(TestEnum));
string[] TestEnumNames = Enum.GetNames(typeof(TestEnum));
var result = TestEnumNames[Array.IndexOf(TestEnumValues, input)];
Console.WriteLine(result);
