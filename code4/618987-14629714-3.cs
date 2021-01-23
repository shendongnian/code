        /// <summary>
        /// Update the textbox text with the value that is in the VM.
        /// </summary>
        void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // This textbox only cares about the property it is bound to
            if (e.PropertyName != MyViewModel.ValueStrPropertyName)
                return;
            // "this" here refers to the actual textbox since I'm in a custom control
            //  that derives from TextBox
            BindingExpression bindingExp = this.GetBindingExpression(TextBox.TextProperty);
            // the version that the ViewModel has (a potentially modified version of the user's string)
            String viewModelValueStr;
            
            viewModelValueStr = (bindingExp.DataItem as MyViewModel).ValueStr;
           
            if (viewModelValueStr != this.Text)
            {
                // Store the user's old caret position (relative to the end of the str) so we can restore it
                //  after updating the text from the ViewModel's corresponding property.
                int oldCaretFromEnd = this.Text.Length - this.CaretIndex;
                // Make the TextBox's Text get the updated value from the ViewModel
                this.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
                // Restore the user's caret index (relative to the end of the str)
                this.CaretIndex = this.Text.Length - oldCaretFromEnd;
            }
        }
