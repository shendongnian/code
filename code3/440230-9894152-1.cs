    public class BatchKey
    {
        public int BatchId {get;set;}
        ...
    }
    ...
            group a by new BatchKey
            {
                BatchId = a.BATCH_ID,
                ...
