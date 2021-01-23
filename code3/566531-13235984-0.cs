    /// <summary>NHibernate class mapping file for <see cref="Action"/>.</summary>
	internal sealed class ActionMapper : ClassMap<Action>
	{
		/// <summary>Constructor.</summary>
		public ActionMapper()
		{
			DiscriminateSubClassesOnColumn("ClassType").Not.Nullable();
			Id(x => x.Id);
		}
	}
	/// <summary>NHibernate class mapping file for <see cref="SetText"/>.</summary>
	internal sealed class SetTextMapper : SubclassMap<SetText>
	{
		public SetTextMapper()
		{
			DiscriminatorValue(typeof(SetText).Name);
			
			Map(x => x.Text).Column("Arg1").CustomType<StringArgType>();
		}
	}
	/// <summary>NHibernate class mapping file for <see cref="Sleep"/>.</summary>
	internal sealed class SleepMapper : SubclassMap<Sleep>
	{
		public SleepMapper()
		{
			DiscriminatorValue(typeof(Sleep).Name);
			Map(x => x.Duration).Column("Arg1").CustomType<TimeSpanArgType>();
		}
	}
	internal class StringArgType : BaseImmutableUserType<String>
	{
		public override SqlType[] SqlTypes
		{
			// All arguments map to strings in the database
			get { return new[] {new SqlType(DbType.String)}; }
		}
		public override object NullSafeGet(IDataReader Reader, string[] Names, object Owner)
		{
			return NHibernateUtil.String.NullSafeGet(Reader, Names[0]).As<String>();
		}
		public override void NullSafeSet(IDbCommand Command, object Value, int Index)
		{
			NHibernateUtil.String.NullSafeSet(Command, Value, Index);
		}
	}
	internal class TimeSpanArgType : BaseImmutableUserType<TimeSpan>
	{
		public override SqlType[] SqlTypes
		{
			// All arguments map to strings in the database
			get { return new[] {new SqlType(DbType.String)}; }
		}
        public override object NullSafeGet(IDataReader Reader, string[] Names, object Owner)
		{
			return NHibernateUtil.TimeSpan.NullSafeGet(Reader, Names[0]).As<TimeSpan?>();
		}
		public override void NullSafeSet(IDbCommand Command, object Value, int Index)
		{
			object val = DBNull.Value;
			if (Value != null)
			{
				TimeSpan timespan = (TimeSpan)Value;
				val = timespan.Ticks;
			}
			NHibernateUtil.String.NullSafeSet(Command, val, Index);
		}
	}
