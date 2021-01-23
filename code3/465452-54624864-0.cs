    private void Button_Click(object sender, RoutedEventArgs e)
    {
        PrintDialog _PrintDialog = new PrintDialog();
        _PrintDialog.PrintQueue = new PrintQueue(new PrintServer(), "Printer Name");
        _PrintDialog.PrintVisual(CanvasOrAnyVisualName, "Printing Job Name");
    }
