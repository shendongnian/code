    IEnumerable<MyEnum> query = Enum.GetValues(typeof(MyEnum))
        .Cast<MyEnum>()
        .Where(x => (x & MyEnum.Vowels) == MyEnum.None);
    foreach (MyEnum item in query) {
        ...
    }
