    var query = Enum.GetValues(typeof(MyEnum))
        .Cast<MyEnum>()
        .Except(new MyEnum[] { MyEnum.A, MyEnum.E });
    foreach (MyEnum item in query) {
        ...
    }
