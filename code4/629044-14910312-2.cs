    public static class TextBoxExtensions {
      public static TextBox Copy(this TextBox textBoxToCopy) {
        var copiedTextBox = new TextBox {
          copiedTextBox = textBoxToCopy.Size,
          copiedTextBox = textBoxToCopy.Location,
          copiedTextBox = textBoxToCopy.Multiline
        };
      }
    }
