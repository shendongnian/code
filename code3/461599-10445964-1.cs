        public class DrivePairs: IEquatable<DrivePairs>
        {
            public int Start { get; set; }
            public int End { get; set; }
    
            public bool Equals(DrivePairs other)
            {
                return (this.Start == other.Start && this.End == other.End)
            }
        } 
