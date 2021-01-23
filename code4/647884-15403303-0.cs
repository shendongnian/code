    // I prefer using Path.Combine over string concatenation, but both will work.
    // You might want to change "Identitys" to "Identities" though :)
    string file = Path.Combine(@"C:\", "SimpleSkype", "Identitys", dd + ".jpg");
    SaveSkypeAvatarToDisk(u.Handle, file);
    using (Image image = Image.FromFile(file))
    {
        ...
    }
