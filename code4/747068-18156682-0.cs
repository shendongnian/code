    public string LastNameText
    {
        get { return LastName.Text; }
        set { LastName.Text = value; }
    }
    <TextBox Name="LastName" x:FieldModifier="private"/>
