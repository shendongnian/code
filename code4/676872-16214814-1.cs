    MyClass myObj = new MyClass() { MyProperty1 = "first", MyProperty2 = "second", MyProperty3 = "third" };
    List<string> array = new List<string>();
    foreach (var item in typeof(MyClass).GetProperties())
    {
        array.Add(item.GetValue(myObj, null).ToString());
    }
    var result = string.Join(",", array); //use your own delimiter 
