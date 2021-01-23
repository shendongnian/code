        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text == _originalName) return;
            Model.Name = NameTextBox.Text;
            Model.Save();
            if(NavigationService.CanGoBack) NavigationService.GoBack();
        }
