    void MyButton_OnClick(object sender, RoutedEventArgs e)
    {
        if(mybutton.Content.ToString() == "Add")
        {
            \\ Lines for add
            mybutton.Content = "Save";
        }
        else
        {
            \\ Lines for Save
            mybutton.Content = "Add";    
        }
    }
