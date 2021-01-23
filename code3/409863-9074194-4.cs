    var input = TestEnum.One | TestEnum.Two;
    var values = (TestEnum[])Enum.GetValues(typeof(TestEnum));
    var names = Enum.GetNames(typeof(TestEnum));
    var result = values
        .Select((value, index) => (input & value) != 0 ? names[index] : null)
        .Where(name => name != null);
    var text = string.Join(", ", result);
    Console.WriteLine(text);
