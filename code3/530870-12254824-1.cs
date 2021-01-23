    // give the canvas a name, so you can bind to it
    mainCanvas.Name = "canvas";
    // create the binding for the Canvas's "ActualHeight" property
    var binding = new System.Windows.Data.Binding();
    binding.ElementName = "canvas";
    binding.Path = new PropertyPath("ActualHeight");
    // assign the binding to the StackPanel's "MinHeight" dependency property
    sp.SetBinding(StackPanel.MinHeightProperty, binding);
