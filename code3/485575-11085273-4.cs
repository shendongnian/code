    int dayUsers, allUsers;
    string[] parts = RxString.Split('\'', ':');
    if (parts.Length > 5)
    {
        Int32.TryParse(parts[2].Trim(), out dayUsers);
        Int32.TryParse(parts[5].Trim(), out allUsers);
    }
