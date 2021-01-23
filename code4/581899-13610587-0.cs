    public interface IDestinationDataOperations
    {
        // Get destinations by date.
        IEnumerable<string> GetDestinationsByDate(DateTime asOf);
    }
