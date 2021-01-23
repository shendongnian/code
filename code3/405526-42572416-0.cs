     public static string NextControlValue(string originalValue, int selectStart, int selectLength, string keyChar)
        {
            if (originalValue.Length > selectStart)
            {
                if (selectLength > 0)
                {
                    originalValue = originalValue.Remove(selectStart, selectLength);
                    return NextControlValue(originalValue, selectStart, 0, keyChar);
                }
                else
                {
                    return originalValue.Insert(selectStart, keyChar);
                }
            }
            else
            {
                return originalValue + keyChar;
            }
        }
    var previewValue = NextControlValue(textbox.Text, textbox.SelectionStart, textbox.SelectionLength, e.KeyChar + "");
