    public DBBufferMessageLocationMap()
    {
        Id(x => x.ID, "ID").GeneratedBy.Identity().UnsavedValue(DBBufferMessageLocation.UNSET_ID);
    }
    public const int UNSET_ID = -1;
    public DBBufferMessageLocation()
    {
        Id = UNSET_ID;
    }
