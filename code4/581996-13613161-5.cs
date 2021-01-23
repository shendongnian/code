    public class LambdaGroupDescription<T> : GroupDescription
	{
		public Func<T, object> GroupDelegate { get; set; }
		public LambdaGroupDescription(Func<T, object> groupDelegate)
		{
			this.GroupDelegate = groupDelegate;
		}
		public override object GroupNameFromItem(object item, int level, System.Globalization.CultureInfo culture)
		{
			return this.GroupDelegate((T)item);
		}
	}   
