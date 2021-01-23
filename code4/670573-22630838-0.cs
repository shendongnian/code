    class CustomAutoCompleteBox : System.Windows.Controls.AutoCompleteBox
    {
        private bool dropDown = false;
        protected override void OnDropDownClosing(System.Windows.Controls.RoutedPropertyChangingEventArgs<bool> e)
        {
            base.OnDropDownClosing(e);
            dropDown = true;
        }
        protected override void OnSelectionChanged(System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (!dropDown)
                base.OnSelectionChanged(e);
            else
                dropDown = false;
        }
    }
