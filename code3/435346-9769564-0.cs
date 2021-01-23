    private static TimeSpan GetTimeRemainingUntilPasswordExpiration(string domain, string userName)
    {
        using (var userEntry = new System.DirectoryServices.DirectoryEntry(string.Format("WinNT://{0}/{1},user", domain, userName)))
        {
            var maxPasswordAge = (int)userEntry.Properties.Cast<System.DirectoryServices.PropertyValueCollection>().First(p => p.PropertyName == "MaxPasswordAge").Value;
            var passwordAge = (int)userEntry.Properties.Cast<System.DirectoryServices.PropertyValueCollection>().First(p => p.PropertyName == "PasswordAge").Value;
            return TimeSpan.FromSeconds(maxPasswordAge) - TimeSpan.FromSeconds(passwordAge);
        }
    }
