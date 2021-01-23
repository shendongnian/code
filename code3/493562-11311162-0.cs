    private bool IsDirty(Status status)
    {
        return status.GetAdded().Count + status.GetChanged().Count + status.GetConflicting().Count +
               status.GetMissing().Count + status.GetModified().Count + status.GetRemoved().Count +
               status.GetUntracked().Count > 0;
    }
