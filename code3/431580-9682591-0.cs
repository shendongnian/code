     private void finishConfigButton_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            errorLabel.Visibility = System.Windows.Visibility.Collapsed;
            validationProfile.IsBusy = true;
            finishConfigButton.IsEnabled = false;
            backToLoginHyperlink.IsEnabled = false;
            bool validated = false;
            string newName = newNameTextBox.Text;
            string newEmail = newEmailTextBox.Text;
            string newUsername = newUsernameTextBox.Text;
            string newPassword = newPasswordPasswordBox.Password;
            string errorMessage = "Unknown error.";
            worker.DoWork += (o, ea) =>
            {
                if (newUser.ValidateNewUserInformation(newName, newEmail, newUsername, newPassword, ref errorMessage))
                {
                    string activeDir = Environment.SystemDirectory.Substring(0, 1) + @":\Users\" + Environment.UserName + @"\My Documents\SSK\Users";
                    string newPath = System.IO.Path.Combine(activeDir, newUser.Username);
                    Directory.CreateDirectory(newPath);
                    newUser.SaveUserData(newUser);
                    newPath = System.IO.Path.Combine(activeDir, newUser.Username + @"\Settings");
                    Directory.CreateDirectory(newPath);
                    newUserSettings.SetDefaultValues();
                    newUserSettings.SaveSettings(newUser, newUserSettings);
                    validated = true;
                }
                else
                    ea.Cancel = true;
            };
            worker.RunWorkerCompleted += (o, ea) =>
            {
                if (validated)
                {
                    IntelliMonitorWindow intelliMonitor = new IntelliMonitorWindow(newUser, newUserSettings);
                    intelliMonitor.Show();
                    this.Close();
                }
                validationProfile.IsBusy = false;
                finishConfigButton.IsEnabled = true;
                backToLoginHyperlink.IsEnabled = true;
                errorLabel.Visibility = System.Windows.Visibility.Visible;
                errorLabel.Content = errorMessage;
            };
            worker.RunWorkerAsync();
        }
