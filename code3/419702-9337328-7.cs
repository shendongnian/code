    public interface IRecord<PK> {
        PK ID { get; }
        
        bool IsValid { get; }
        string[] Errors { get; }
    }
