    using (StreamReader file = File.OpenText(basePath + "jsontxt"))
    {
        string s = file.ReadToEnd();
    }
    if (verificationCode != s.GetHashCode())
    {
        // Malicious fart joke eminent!
    }
