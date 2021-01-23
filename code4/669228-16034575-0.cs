    PropertyInfo textEditorProperty = typeof (TextBox).GetProperty(
       "TextEditor", BindingFlags.NonPublic | BindingFlags.Instance);
    object textEditor = textEditorProperty.GetValue(hexTextBox, null);
    // set _OvertypeMode on the TextEditor
    PropertyInfo overtypeModeProperty = textEditor.GetType().GetProperty(
       "_OvertypeMode", BindingFlags.NonPublic | BindingFlags.Instance);
    overtypeModeProperty.SetValue(textEditor, true, null);
