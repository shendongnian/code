    delegate void voidDelegate();
    private void treeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        var tree = (TreeView)sender;
        var selectedItem = tree.SelectedItem as Child;
        if (selectedItem != null)
        {
            int selectionStart = scriptTextBox.SelectionStart;
            string selectedText = selectedItem.Name;
            voidDelegate giveFocusDelegate = new  voidDelegate(giveFocus);  
            Dispatcher.BeginInvoke(giveFocusDelegate, new object[] { });
            scriptTextBox.SelectedText = selectedText;         
        }
    }
    private void giveFocus()
    {
        scriptTextBox.Focus();
    }    
