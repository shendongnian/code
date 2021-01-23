        /// <summary>
        /// It is impossible to simply click a ComboBox to select the shown value again. It always drops down the list of options but
        ///     doesn't raise SelectionChanged event if the value selected from the list is the same as before
        ///     
        /// To handle this, a transparent button is overlaid over the ComboBox (but not its dropdown arrow) to allow reselecting the old value
        /// Thus clicking over the dropdown arrow allows the user to select a new option from the list, but
        ///     clicking anywhere else in the Combo re-selects the previous value
        /// </summary>
        private void ClickedComboButValueHasntChanged(object sender, RoutedEventArgs e)
        {
            //You could also dummy up a SelectionChangedEvent event and raise it to invoke Function_SelectionChanged handler, below 
            FunctionEntered(NewFunctionSelect.SelectedValue as string);
        }
        private void Function_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FunctionEntered(e.AddedItems[0] as string);
        }
