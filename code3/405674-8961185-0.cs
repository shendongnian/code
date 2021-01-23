    // Inside the UserControl
    public string ExtraProperty
    {
        get { return myTextBox.Attributes["extraproperty"]; }
        set { myTextBox.Attributes["extraproperty"] = value; }
    }
    
    // Consumers of the UserControl
    <my:CustomUserControl ... ExtraProperty="extravalue" />
