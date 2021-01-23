    public enum ApprovalItemState
    {
        Enqueued = 1,
        Approved = 2,
        Denied = 7,
        Acknowledged = 18,
        ApprovalAcknowledged = Approved + Acknowledged,
        DenialAcknowledged = Denied + Acknowledged
    }
