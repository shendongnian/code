    namespace Persistence.Utils
    {
        public class SQLUtils
        {
            /// <summary>
            /// Builds a paginated/limited query from a SELECT SQL.
            /// </summary>
            /// <param name="startRow">Start row</param>
            /// <param name="numberOfRows">Number/quatity of rows to be expected</param>
            /// <param name="sql">Original SQL (without its ordering clause)</param>
            /// <param name="orderingClause">MANDATORY: ordering clause (including ORDER BY keywords)</param>
            /// <returns>Paginated SQL ready to be executed.</returns>
            /// <remarks>SELECT keyword of original SQL must be placed exactly at the beginning of the SQL.</remarks>
    		public static string GetPaginatedSQL(int startRow, int numberOfRows, string sql, string orderingClause)
            {
                // Ordering clause is mandatory!
                if (String.IsNullOrEmpty(orderingClause))
                    throw new ArgumentNullException("orderingClause");
    
                // numberOfRows here is checked of disable building paginated/limited query
                // in case is not greater than 0. In this case we simply return the
                // query with its ordering clause appended to it. 
                // If ordering is not spe
                if (numberOfRows <= 0)
                {
                    return String.Format("{0} {1}", sql, orderingClause);
                }
                // Extract the SELECT from the beginning.
                String partialSQL = sql.Remove(0, "SELECT ".Length);
    
                // Build the limited query...
                return String.Format(
                    "SELECT * FROM ( SELECT ROW_NUMBER() OVER ({0}) AS rn, {1} ) AS SUB WHERE rn > {2} AND rn <= {3}",
                    orderingClause,
                    partialSQL,
                    startRow.ToString(),
                    (startRow + numberOfRows).ToString()
                );
            }
        }
    }
