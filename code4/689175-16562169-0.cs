	public class MWCompetitionContestantsDetails
	{
		private string _firstName;
		
		public string FirstName
		{
			get
			{
				return this._firstName;
			}
			set
			{
				if(!IsNullOrEmpty(value))
				{
					this._firstName = value;
				}
			}
		}		
		
		.........
		
		public static bool IsNullOrEmpty<T>(T value)
		{
			if (typeof(T) == typeof(string))
				  return string.IsNullOrEmpty(value as string);
			return value.Equals(default(T));
		} 
	}
