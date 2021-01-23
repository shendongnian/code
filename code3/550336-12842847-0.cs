    public static DependencyProperty TestProperty 
      = DependencyProperty.Register(
          "Test", typeof(string), typeof(YourActivity));
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [ValidationOption(ValidationOption.Optional)]
    [Browsable(true)]
    [Description("Enter ....")]
    public string Test
    {
       get { return ((string)(base.GetValue(YourActivity.TestProperty))); }
       set { base.SetValue(YourActivity.TestProperty, value); }
    }
