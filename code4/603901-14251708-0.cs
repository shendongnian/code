    private Task<string> OpenPopupAsync()
    {
        var taskSource = new TaskCompletionSource<string>();
        // Create a Popup
        var Pop = new Popup() { IsOpen = true };
        // Create a StackPanel for the Buttons
        var SPanel = new StackPanel() { Background = MainGrid.Background };
        // Set the comment
        var TxtBlockComment = new TextBlock { Margin = new Thickness(20, 5, 20, 5), Text = Obj.Comment };
        // Set the value
        var TxtBoxValue = new TextBox { Name = "MeasureValue" };
        TxtBoxValue.KeyUp += (sender, e) => { VerifyKeyUp(sender, Measure); };
        // Create the button
        var ButtonFill = new Button { Content = Loader.GetString("ButtonAccept"), Margin = new Thickness(20, 5, 20, 5), Style = (Style)App.Current.Resources["TextButtonStyle"] };
        ButtonFill.Click += (sender, e) => { Pop.IsOpen = false; taskSource.SetResult(TxtBoxValue.Text); };
        // Add the items to the StackPanel
        SPanel.Children.Add(TxtBlockComment);
        SPanel.Children.Add(TxtBoxValue);
        SPanel.Children.Add(ButtonFill);
        // Set the child on the popup
        Pop.Child = SPanel;
        return taskSource.Task;
    }
