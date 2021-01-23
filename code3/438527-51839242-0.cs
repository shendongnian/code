    public interface IReportParams
    {
        IEnumerable<Guid> SelectedItems { get; }
        IEnumerable<StatusEnum> SelectedStatuses { get; }
    }
