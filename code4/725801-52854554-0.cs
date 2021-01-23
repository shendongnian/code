        private void TextBox_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                ((Control)sender).ToolTip = e.Error.ErrorContent.ToString();
            }
            else
            {
                if (!((BindingExpressionBase)e.Error.BindingInError).HasError)
                    ((Control)sender).ToolTip = "";
            }
        }
