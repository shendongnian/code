    protected override void OnKeyDown(KeyEventArgs e)
     {
         if (IsPastingAndClipboardTextIsTooLarge(e.Key))
         {
            int textToFit = (MaxLength - Text.Length + SelectionLength);
            if (textToFit > 0)
            {
               var startIndex = SelectionStart;
               var textToPaste = Clipboard.GetText().Substring(0, Math.Min(textToFit, Clipboard.GetText().Length));
               int caretPosition = startIndex + textToPaste.Length;
               if (SelectionLength > 0)
                  Text = Text.Remove(startIndex, SelectionLength);
               Text = Text.Insert(startIndex, textToPaste);
               SelectionStart = caretPosition;
            }
            e.Handled = true;
         }
         else base.OnKeyDown(e);
      }
      public bool IsPastingAndClipboardTextIsTooLarge(Key key)
      {
         return key == Key.V && ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control) &&
                Clipboard.ContainsText() &&
                Text.Length + Clipboard.GetText().Length > MaxLength - SelectionLength;
      } 
