    public abstract class RangeBase
	{
		public int MinValue { get; private set; }
		public int MaxValue { get; private set; }
		public abstract Delegate SomeDelegate { get; }
		protected RangeBase(int minValue, int maxValue)
		{
			MinValue = minValue;
			MaxValue = maxValue;
		}
		public bool BelongsToRange(int number)
		{
			return number > MinValue && number < MaxValue;
		}
	}
