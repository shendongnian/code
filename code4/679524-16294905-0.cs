    if (sender is ComboBox || sender is TextBox)
    {
      var type = Type.GetType(sender.GetType().AssemblyQualifiedName, false, true);
      var textValue = type.GetProperty("Text").GetValue(sender, null);
    }
