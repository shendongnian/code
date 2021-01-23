    public interface IFQuickAudit {
        Nullable<DateTimeOffset> CreatedOn { get; set; }
        Nullable<long> CreatedBy { get; set; }
        Nullable<DateTimeOffset> ChangedOn { get; set; }
        Nullable<long> ChangedBy { get; set; }
    }
