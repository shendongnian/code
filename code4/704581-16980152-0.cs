    public class DataFieldSet : IEquatable<DataFieldSet>
    {
        public int Id { get; set; }
    
        public bool Equals(DataFieldSet other)
        {
            return other != null && this.Id == other.Id;
        }
    }
