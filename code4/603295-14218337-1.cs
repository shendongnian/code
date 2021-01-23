    List<dynamic> list = new List<dynamic>();
    
    list.Add(new step{ StepNumber = 5 });
    list.Add(new AutoStep{ StepNumber = 3 });
    
    foreach (var item in list.OrderBy(x => x.StepNumber))
    {
        item.Foo();
    }
