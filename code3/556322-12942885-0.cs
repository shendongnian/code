          UserIdentity user;
    private void UserID_Save_Click(object sender, RoutedEventArgs e)
        {
            user = new UserIdentity()
            {
                Name = textUserName.Text,
                Age = textUserAge.Text,
                Gender = textUserGender.Text,
                Department = textUserDepartment.Text
    
            };
        }
