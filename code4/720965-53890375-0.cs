    public interface IProperty<T>
	{
		string _value { get; set; }
		T getValue();
	};
	public class BooleanProperty : IProperty<bool>
	{
		public string _value { get; set; }
		public bool getValue()
		{
			// Business logic for "yes" => true
			return false;
		}
	}
	public class DateTimeProperty : IProperty<DateTime>
	{
		public string _value { get; set; }
		public DateTime getValue()
		{
			// Business logic for "Jan 1 1900" => a DateTime object
			return DateTime.Now;
		}
	}
