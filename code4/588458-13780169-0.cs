    public class Appointment
    {
        private int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    
        public Appointment( int id, DateTime start, DateTime end )
        {
            Start = start;
            End = end;
            Id = id;
        }
    }
    public class AppointmentEqualityComparer<T> : IEqualityComparer<T> where T : Appointment
    {
        #region IEqualityComparer<T> Members
    
        public bool Equals( T x, T y )
        {
            return ( x == null && y == null )
                    || ( ( x != null && y != null ) && ( x.Start == y.Start && x.End == y.End ) );
        }
    
        public int GetHashCode( T obj )
        {
            if( obj == null )
            {
                throw new ArgumentNullException( "obj" );
            }
    
            return obj.GetHashCode();
        }
    
        #endregion
    }
