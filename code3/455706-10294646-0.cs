    using (EntitiesDatabase context = new EntitiesDatabase())
    {
      context.Attach(UserHandler.Instance.User);
      if (UserHandler.Instance.User is Admin)
      {
        ((Admin)UserHandler.Instance.User).ProjectManagers.Add(
           new ProjectManager(firstNameTextBox.Text, lastNameTextBox.Text, usernameTextBox.Text, passwordTextBox.Text));
      }
      else if (UserHandler.Instance.User is ProjectManager)
      {
        ((ProjectManager)UserHandler.Instance.User).Developers.Add(
            new Developer(firstNameTextBox.Text, lastNameTextBox.Text, usernameTextBox.Text, passwordTextBox.Text));
      }
      context.SaveChanges();
    }
