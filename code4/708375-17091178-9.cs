	using System.Data;
	using System.Data.SqlClient;
	namespace ASC.Code.Forms.Helper
	{
		public interface IDataPageRetriever
		{
			DataTable SupplyPageOfData(int lowerPageBoundary, int rowsPerPage);
			SqlDataAdapter getAdapter();
		}
	}
	
