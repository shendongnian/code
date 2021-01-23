	public class LogFileEntry :IEquatable<LogFileEntry>
	{
		private readonly string[] _rows;
		public LogFileEntry(string[] rows)
		{
			_rows = rows;
		}
		public override int GetHashCode()
		{
			return 
				_rows[0].GetHashCode() << 3 | 
				_rows[2].GetHashCode() << 2 | 
				_rows[1].GetHashCode() << 1 | 
				_rows[0].GetHashCode();
		}
		#region Implementation of IEquatable<LogFileEntry>
		public override bool Equals(Object obj)
		{
			if (obj == null) 
				return base.Equals(obj);
		
			return Equals(obj as LogFileEntry);  
		} 
   
		public bool Equals(LogFileEntry other)
		{
		    if(other == null) 
                return false;
			
            return _rows.SequenceEqual(other._rows);
		}
		#endregion
	}
