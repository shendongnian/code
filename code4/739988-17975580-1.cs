    var typeOfDp = dp.GetType();
    var nameProperty = typeOfDp
                        .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                        .Single(t => t.Name == "Name");
    var name = nameProperty.GetValue(dp);
    var binding = new Binding(name)  //Maybe it will work?
    {
        Source = frameworkElement
    };
