	public class Subscriber : IEntity
	{
		...
		private ICollection<HelpChannel> _subscribedList { get; set; } // ICollection!
		public class SubscriberMapper : EntityTypeConfiguration<Subscriber>
		{
			public SubscriberMapper()
			{
				HasMany(s => s._subscribedList);
			}
		}
	}
