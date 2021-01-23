	public class BaseFoo
	{
		public virtual MyDataBase MoreData
		{
			get
			{
				return _data;
			}
		}
	}
	public class GenericFoo<T> : BaseFoo where T : MyDataBase
	{
		public override MyDataBase MoreData
		{
			get
			{
				return _someOtherData;
			}
		}
	}
	
	// which property is called?
	var data = ((BaseFoo)foo).MoreData;
