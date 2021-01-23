    bool IsUserPresent(string username)
    {
        username = username.ToLower();
        var doc = XDocument.Load(filePath);
        return doc
          .Descendants("user")
          .Any(u => u.Element("username").Value == username));
    }
