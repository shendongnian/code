    void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        // Find the Paste command of the avalon edit
        foreach (var commandBinding in textEditor.TextArea.CommandBindings.Cast<CommandBinding>())
        {
            if (commandBinding.Command == ApplicationCommands.Paste)
            {
                // Add a custom PreviewCanExecute handler so we can filter out newlines
                commandBinding.PreviewCanExecute += new CanExecuteRoutedEventHandler(pasteCommandBinding_PreviewCanExecute);
                break;
            }
        }
    }
    void pasteCommandBinding_PreviewCanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        // Get clipboard data and stuff
        var dataObject = Clipboard.GetDataObject();
        var text = (string)dataObject.GetData(DataFormats.UnicodeText);
        // normalize newlines so we definitely get all the newlines
        text = TextUtilities.NormalizeNewLines(text, Environment.NewLine);
        // if the text contains newlines - replace them and paste again :)
        if (text.Contains(Environment.NewLine))
        {
            e.CanExecute = false;
            e.Handled = true;
            text = text.Replace(Environment.NewLine, " ");
            Clipboard.SetText(text);
            textEditor.Paste();
        }
    }
