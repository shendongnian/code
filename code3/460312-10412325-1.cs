    DataTemplate temp = new DataTemplate();
    temp.DataType = typeof (MyViewModel);
    FrameworkElementFactory fac = new FrameworkElementFactory(typeof(MyView));
    temp.VisualTree = fac;
    View.WindowName.Resources.Add(new DataTemplateKey(typeof(MyViewModel)), temp );
