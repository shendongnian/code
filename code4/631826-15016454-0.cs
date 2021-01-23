    ListPicker picker = new ListPicker()
    {
        Header = "SOME HEADER",
        ItemsSource = YourViewModel.SomeCollectionWithItems,
        Margin = new Thickness(12, 42, 24, 18)
    };
    
    CustomMessageBox messageBox = new CustomMessageBox()
    {
        Caption = "This is a message box",
        Message = "Select one of the items from the list.",
        Content = picker,
        LeftButtonContent = "ok",
        RightButtonContent = "cancel"
    };
