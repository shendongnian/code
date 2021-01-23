    using (MediaProfitsDb db = new MediaProfitsDb())
    {
        db.UserProfiles.Attach(pw.UserProfile);
        db.ProtectedPasswords.Add(pw);
        db.SaveChanges();
        return true;
    }
