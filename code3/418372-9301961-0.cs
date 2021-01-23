    public enum ApprovalItemState
    {
        Enqueued = 1,
        Approved = 2,
        Denied = 3,
        Acknowledged = 4,
        ApprovalAcknowledged = ApprovalItemState.Approved + ApprovalItemState.Acknowledged,
        DenialAcknowledged = ApprovalItemState.Denied + ApprovalItemState.Acknowledged
    }
