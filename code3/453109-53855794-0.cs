    /// <summary>
    /// Occurs before the record is deleted
    /// </summary>
    public event CancelEventHandler DeletingRecord;
    /// <summary>
    /// Occurs before record changes are discarded (i.e. by a New or Close operation)
    /// </summary>
    public event DiscardingChangesEvent DiscardingChanges;
