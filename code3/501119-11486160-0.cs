    foreach(var subject in subjects)
    {
        db.Subjects.Remove(subject);
    }
    db.SubmitChanges();
