	interface IChart
	{
		string newProperty { get; set; }
	}
	abstract class BaseChart : IChart
	{
		public virtual string newProperty
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}
	}
	class Chart1 : BaseChart
	{
		private string _newProperty;
		public override string newProperty
		{
			get
			{
				return _newProperty;
			}
			set
			{
				_newProperty = value;
			}
		}
	}
	class Chart2 : BaseChart
	{
		
	}
