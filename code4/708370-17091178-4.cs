	using System.Data;
	using System.Data.SqlClient;
	namespace ASC.Code.Forms.Helper
	{
		public class CacheAll
		{
			private static int RowsPerPage;
			// Represents one page of data.   
			public struct DataPage
			{
				public DataTable table;
				public SqlDataAdapter adapter;
				private int lowestIndexValue;
				private int highestIndexValue;
				public DataPage(DataTable table, SqlDataAdapter adapter, int rowIndex)
				{
					this.table = table;
					this.adapter = adapter;
					lowestIndexValue = MapToLowerBoundary(rowIndex);
					highestIndexValue = MapToUpperBoundary(rowIndex);
					System.Diagnostics.Debug.Assert(lowestIndexValue >= 0);
					System.Diagnostics.Debug.Assert(highestIndexValue >= 0);
				}
				public int LowestIndex
				{
					get
					{
						return lowestIndexValue;
					}
				}
				public int HighestIndex
				{
					get
					{
						return highestIndexValue;
					}
				}
				public static int MapToLowerBoundary(int rowIndex)
				{
					// Return the lowest index of a page containing the given index. 
					return (rowIndex / RowsPerPage) * RowsPerPage;
				}
				private static int MapToUpperBoundary(int rowIndex)
				{
					// Return the highest index of a page containing the given index. 
					return MapToLowerBoundary(rowIndex) + RowsPerPage - 1;
				}
				public DataTable getTable()
				{
					return this.table;
				}
				public SqlDataAdapter getAdapter()
				{
					return this.adapter;
				}
			}
			private DataPage[] cachePages;
			private IDataPageRetrieverAll dataSupply;
			public CacheAll(IDataPageRetrieverAll dataSupplier, int rowsPerPage)
			{
				dataSupply = dataSupplier;
				CacheAll.RowsPerPage = rowsPerPage;
				LoadFirstTwoPages();
			}
			// Sets the value of the element parameter if the value is in the cache. 
			private bool IfPageCached_ThenSetElement(int rowIndex,
				int columnIndex, ref string element)
			{
				if (IsRowCachedInPage(0, rowIndex))
				{
					element = cachePages[0].table
						.Rows[rowIndex % RowsPerPage][columnIndex].ToString();
					return true;
				}
				else if (cachePages.Length > 1)
				{
					if (IsRowCachedInPage(1, rowIndex))
					{
						element = cachePages[1].table.Rows[rowIndex % RowsPerPage][columnIndex].ToString();
						return true;
					}
				}
				return false;
			}
			public string RetrieveElement(int rowIndex, int columnIndex)
			{
				string element = null;
				if (IfPageCached_ThenSetElement(rowIndex, columnIndex, ref element))
				{
					return element;
				}
				else
				{
					return RetrieveData_CacheIt_ThenReturnElement(
						rowIndex, columnIndex);
				}
			}
			private void LoadFirstTwoPages()
			{
				DataTable table1 = dataSupply.SupplyPageOfData(DataPage.MapToLowerBoundary(0), RowsPerPage);
				SqlDataAdapter adapter1 = dataSupply.getAdapter();
				DataTable table2 = dataSupply.SupplyPageOfData(DataPage.MapToLowerBoundary(RowsPerPage), RowsPerPage);
				SqlDataAdapter adapter2 = dataSupply.getAdapter();
				cachePages = new DataPage[]{
				new DataPage(table1, adapter1, 0), 
				new DataPage(table2, adapter2, RowsPerPage)};
			}
			private string RetrieveData_CacheIt_ThenReturnElement(
				int rowIndex, int columnIndex)
			{
				// Retrieve a page worth of data containing the requested value.
				DataTable table = dataSupply.SupplyPageOfData(
					DataPage.MapToLowerBoundary(rowIndex), RowsPerPage);
				SqlDataAdapter adapter = dataSupply.getAdapter();
				// Replace the cached page furthest from the requested cell 
				// with a new page containing the newly retrieved data.
				cachePages[GetIndexToUnusedPage(rowIndex)] = new DataPage(table, adapter, rowIndex);
				return RetrieveElement(rowIndex, columnIndex);
			}
			// Returns the index of the cached page most distant from the given index 
			// and therefore least likely to be reused. 
			private int GetIndexToUnusedPage(int rowIndex)
			{
				if (rowIndex > cachePages[0].HighestIndex &&
					rowIndex > cachePages[1].HighestIndex)
				{
					int offsetFromPage0 = rowIndex - cachePages[0].HighestIndex;
					int offsetFromPage1 = rowIndex - cachePages[1].HighestIndex;
					if (offsetFromPage0 < offsetFromPage1)
					{
						return 1;
					}
					return 0;
				}
				else
				{
					int offsetFromPage0 = cachePages[0].LowestIndex - rowIndex;
					int offsetFromPage1 = cachePages[1].LowestIndex - rowIndex;
					if (offsetFromPage0 < offsetFromPage1)
					{
						return 1;
					}
					return 0;
				}
			}
			// Returns a value indicating whether the given row index is contained 
			// in the given DataPage.  
			private bool IsRowCachedInPage(int pageNumber, int rowIndex)
			{
				return rowIndex <= cachePages[pageNumber].HighestIndex &&
					rowIndex >= cachePages[pageNumber].LowestIndex;
			}
			public DataPage[] getCachePages()
			{
				return cachePages;
			}
		}
	}
