    public enum ApprovalItemState 
    {
        Enqueued = 1,
        Approved = 2,
        Denied = 4,
        Acknowledged = 8,
        ApprovalAcknowledged = Approved | Acknowledged,
        DenialAcknowledged =  Denied | Acknowledged 
    } 
