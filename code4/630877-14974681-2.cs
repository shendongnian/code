    var oldIssueVersion = session.Get<Issue>(newIssueVersion.Id);
    session.Delete(oldIssueVersion);
    var conflict = new Conflict<Issue>() { Id = Guid.NewGuid(), IssueKey = oldIssueVersion.Key, OriginalEntity = oldIssueVersion, DateOfConflict = DateTime.Now };
    session.Save(conflict);
    session.Save(newIssueVersion);
