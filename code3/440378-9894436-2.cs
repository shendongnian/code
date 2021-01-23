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
		    if(other == null) return false;
			
			return
				_rows[0].Equals(other._rows[0]) &&
				_rows[1].Equals(other._rows[1]) &&
				_rows[2].Equals(other._rows[2]) &&
				_rows[3].Equals(other._rows[3]);
		}
		#endregion
	}
