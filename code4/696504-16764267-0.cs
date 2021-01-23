        private void AllPages_Checked(object sender, RoutedEventArgs e)
        {
            if (minBox != null) minBox.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            if (maxBox != null) maxBox.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
        }
