	public interface IDataProvider
	{
		 T ExecuteMySelectQuery<T>(Func<IDataReader, T> getMyResult, string selectQuery, Dictionary parameters);
	}
	public interface IDataLayer
	{
		string GetTitle(string myVar);
	}
	
	public class DataLayer 
	{
		private IDataProvider dataProvider;
		
		public DataLayer(IDataProvider dataProvider)
		{
			this.dataProvider = dataProvider;
		}
	}
