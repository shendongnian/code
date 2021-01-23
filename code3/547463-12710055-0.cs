    dynamic MyDynamic = new ExpandoObject();
    MyDynamic.A = "A";
    MyDynamic.B = "B";
    MyDynamic.C = "C";
    MyDynamic.SomeProperty = SomeValue
    MyDynamic.number = 10;
    MyDynamic.Increment = (Action)(() => { MyDynamic.number++; });
