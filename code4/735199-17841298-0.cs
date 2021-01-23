    private static void RemoveProfile(string profileFile, string profileName)
    {
        XDocument xDocument = XDocument.Load(profileFile);
        foreach (var profileElement in xDocument.Descendants("Profile")  // Iterates through the collection of "Profile" elements
                                                .ToList())               // Copies the list (it's needed because we modify it in the foreach (when the element is removed)
        {
            if (profileElement.Attribute("Name").Value == profileName)   // Checks the name of the profile
            {
                profileElement.Remove();                                 // Removes the element
            }
        }
        xDocument.Save(profileFile);
    }
