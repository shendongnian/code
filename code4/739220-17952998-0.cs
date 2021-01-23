    Type type = typeof(EnumType);
    foreach (FieldInfo field in type.GetFields(BindingFlags.Static |
                                               BindingFlags.Public))
    {
        // Fortunately unboxing to the enum's underlying field type works
        int value = (int) field.GetValue(null);
        ListItem item = new ListItem(field.Name, value.ToString());
        TheListBox.Items.Add(item);
    }
