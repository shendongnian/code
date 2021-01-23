    DataGridTemplateColumn col1 = new DataGridTemplateColumn();
    //create the data template 
    DataTemplate headerLayout = new DataTemplate();
    //set up the stack panel 
    FrameworkElementFactory gridFactory = new FrameworkElementFactory(typeof(Grid));
    // define grid's rows  
    var row1 = new FrameworkElementFactory(typeof(RowDefinition));
    gridFactory.AppendChild(row1);
    var row2 = new FrameworkElementFactory(typeof(RowDefinition));
    gridFactory.AppendChild(row2);
    // set up the inwardTextBlock 
    FrameworkElementFactory inwardTextBlock = new FrameworkElementFactory(typeof(TextBlock));
    inwardTextBlock.SetValue(Grid.RowProperty, 0);
    inwardTextBlock.SetValue(TextBlock.TextProperty, "INWARD");
    gridFactory.AppendChild(inwardTextBlock);
    //set up the stack panel 
    FrameworkElementFactory spFactory = new FrameworkElementFactory(typeof(StackPanel));
    spFactory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
    spFactory.SetValue(Grid.RowProperty, 1);
    // set up the grossWeightTextBlock 
    FrameworkElementFactory grossWeightTextBlock = new FrameworkElementFactory(typeof(TextBlock));
    inwardTextBlock.SetValue(TextBlock.TextProperty, "Gross Weight");
    inwardTextBlock.SetValue(TextBlock.WidthProperty, 80);
    spFactory.AppendChild(inwardTextBlock);
    // set up the pureWeightTextBlock 
    FrameworkElementFactory pureWeightTextBlock = new FrameworkElementFactory(typeof(TextBlock));
    inwardTextBlock.SetValue(TextBlock.TextProperty, "Pure Weight");
    inwardTextBlock.SetValue(TextBlock.WidthProperty, 80);
    spFactory.AppendChild(inwardTextBlock);
    // set up the qtyWeightTextBlock 
    FrameworkElementFactory qtyWeightTextBlock = new FrameworkElementFactory(typeof(TextBlock));
    inwardTextBlock.SetValue(TextBlock.TextProperty, "Quantity");
    inwardTextBlock.SetValue(TextBlock.WidthProperty, 80);
    spFactory.AppendChild(inwardTextBlock);
    gridFactory.AppendChild(spFactory);
    // set the visual tree of the data template 
    headerLayout.VisualTree = gridFactory;
    // set the header template
    col1.HeaderTemplate = headerLayout;
