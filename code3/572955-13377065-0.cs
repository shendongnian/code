    var dpFactory = new FrameworkElementFactory(typeof (DockPanel));
    dpFactory.Name = "myDockPanelFactory";
    var ellipseVisBinding = new Binding("IsAdmin");
    ellipseVisBinding.Converter = new BooleanToVisibilityConverter();
    fef.SetBinding(Ellipse.VisibilityProperty, ellipseVisBinding);
