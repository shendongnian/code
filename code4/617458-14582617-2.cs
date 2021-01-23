    var test = new Test();
    test.PropertyChanged += (sender, e) =>
    	{
    		// Put anything you want here, for example change your
    		// textbox content
    		Console.WriteLine("Property {0} changed", e.PropertyName);
    	};
    
    // Changes the property value
    test.MyProperty = "test";
