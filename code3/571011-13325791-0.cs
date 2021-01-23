    public void Button_Click_1(object sender, RoutedEventArgs e)
    {
        myText = "Clicked";
        BindingOperations.GetBindingExpressionBase(myTextBox, TextBlock.TextProperty).UpdateTarget();
    }
