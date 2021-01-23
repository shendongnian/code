    IEnumerable<PropertyInfo> properties = this.GetType().GetRuntimeProperties();
    var textbox = properties.Single(prop =>
        String.Equals(prop.Name, "_1", StringComparison.OrdinalIgnoreCase))
        .GetValue() as TextBox;
    if (textbox != null)
    {
        var originalValue = textbox.Text;
        textbox.Text = "new value";
    }
