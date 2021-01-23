	public class GenericFoo<T> : BaseFoo
		where T : MyDataBase
	{
		public T GetData()
		{
			return (T)base.Data;
		}
	}
