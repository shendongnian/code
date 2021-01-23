    if (e.Key == Windows.System.VirtualKey.Tab) 
    {
    	e.Handled = true;
    	string SelectionText = "";
    	TextBox.Document.Selection.GetText(Windows.UI.Text.TextGetOptions.None, SelectionText);
    	TextBox.Document.Selection.TypeText(char(9) + SelectionText);
    }
