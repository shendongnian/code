    ViewBag.Foo = new myDataModelType[allSpark.Length];
    for (int i = 0; i < allSpark.Length; i++)
    {
    
    ViewBag.Foo[i] = new ObjectThatHasNameProperty();
        ViewBag.Foo[i].Name = allSpark[i].Users.Name;
       
    }
