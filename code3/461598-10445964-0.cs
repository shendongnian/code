        public class DrivePairs: IEquatable<DrivePairs>
      {
        public int Start { get; set; }
        public int End { get; set; }
    
    
    
        public bool Equals(DrivePairs other)
        {
          if (this.Start == other.Start && this.End == other.End)
          {
            return true;
          }
          else
          {
            return false;
          }
        }
      } 
