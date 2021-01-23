    							private IEnumerable<AppealsGridViewModel> GetDataNew(string sortString, int pageNumber, int pageSize)
						{
							var totalRowCount = new SqlParameter
							{
								ParameterName = "@TotalRowCount",
								SqlDbType = SqlDbType.Int,
								Direction = ParameterDirection.Output
							};
							var totalPropertyCount = new SqlParameter
							{
								ParameterName = "@TotalPropertyCount",
								SqlDbType = SqlDbType.Int,
								Direction = ParameterDirection.Output
							};
							var paramList = new object[] {
								new SqlParameter {ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = 5}
								, new SqlParameter {ParameterName = "@AccountId", SqlDbType = SqlDbType.Int, Value = 0}
								, new SqlParameter {ParameterName = "@IsServiceCenterUser", SqlDbType = SqlDbType.Bit, Value = 0}
								, new SqlParameter {ParameterName = "@PageNumber", SqlDbType = SqlDbType.Int, Value = (pageNumber + 1)}
								, new SqlParameter {ParameterName = "@PageSize", SqlDbType = SqlDbType.Int, Value = pageSize}
								, new SqlParameter {ParameterName = "@SortOrder", SqlDbType = SqlDbType.VarChar, Value = sortString}
								, totalRowCount
								, totalPropertyCount
							};
							var s = _dataContext.ExecuteStoreQuery<AppealsGridViewModel>("exec atAppealsSearch @CompanyId, @AccountId, @IsServiceCenterUser, @PageNumber, @PageSize, @SortOrder, @TotalRowCount out, @TotalPropertyCount out", paramList).ToList();
							var appealCount = totalRowCount.Value;
							var propertyCount = totalPropertyCount.Value;
							return s;
						}
				ALTER PROCEDURE [dbo].[atAppealsSearch]
					@CompanyId INT
					, @AccountId INT = 0
					, @IsServiceCenterUser BIT = 0
					, @PageNumber INT = 1
					, @PageSize INT = 25
					, @SortOrder VARCHAR(MAX)
					, @TotalRowCount int OUT
					, @TotalPropertyCount int OUT
					AS
				SELECT @TotalRowCount = 33124
				SELECT @TotalPropertyCount = 555
				EXEC SP_EXECUTESQL @Query
