    public bool IsValueTypeBoolean
    {
        get
        {
             ...Conditions that will return true for CheckBox.
        }
    }
    
    public bool IsValueTypeOther
    {
        get
        {
             return !this.IsValueBoolean;
        }
    }
    <TextBox Grid.Column="2" Visibility="{Binding IsValueTypeOther, Converter={StaticResource visibilityConverter}}"/> 
    <CheckBox Grid.Column="2" Visibility="{Binding IsValueTypeBoolean, Converter={StaticResource visibilityConverter}}"/> 
