    private void ApplyChangesToConnectionString()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["SomeUniqueName"].ConnectionString = GetChangesAppliedConnectionString(connectionStringsSection.ConnectionStrings["SomeUniqueName"].ConnectionString);
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");   
        }
