    private string SamplePropery {get; set;}
    private string FormatMethod(string value) {}
    
    private void SampleExecute()
    {
        // format and set to property
        SampleProperty = FormatMethod("hello world");
        // get property and format the value
        string _value = FormatMethod(SampleProperty);
    }
