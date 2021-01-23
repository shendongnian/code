    public YourEnum SelectedOption { get; set; }
    public IDictionary<string, YourEnum> Options = new Dictionary<string, YourEnum?>();
    
    Options.Add("Select", null);
    Options.Add("Option 1", YourEnum.Option1);
    ...
    Options.Add("Option N", YourEnum.OptionN);
