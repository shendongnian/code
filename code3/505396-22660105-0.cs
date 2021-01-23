    using System.Linq;
    using System.Text.RegularExpressions;
    namespace System.Data.Entity {
        public static class DbContextExtensions {
            /// <summary>
            /// Efficiently deletes all data from any database tables used by the specified entity framework query. 
            /// </summary>
            /// <typeparam name="TContext">The DbContext Type on which to perform the delete.</typeparam>
            /// <typeparam name="TEntity">The Entity Type to which the query resolves.</typeparam>
            /// <param name="ctx">The DbContext on which to perform the delete.</param>
            /// <param name="deleteQuery">The query that references the tables you want to delete.</param>
            public static void BulkDelete<TContext, TEntity>(this TContext ctx, Func<TContext, IQueryable<TEntity>> deleteQuery) where TContext : DbContext {
                var findTables = new Regex(@"(?:FROM|JOIN)\s+(\[\w+\]\.\[\w+\])\s+AS");
                var qry = deleteQuery(ctx).ToString();
                // Get list of all tables mentioned in the query
                var tables = findTables.Matches(qry).Cast<Match>().Select(m => m.Result("$1")).Distinct().ToList();
                // Loop through all the tables, attempting to delete each one in turn
                var max = 30;
                var exception = (Exception)null;
                while (tables.Any() && max-- > 0) {
                    // Get the next table
                    var table = tables.First();
                    try {
                        // Attempt the delete
                        ctx.Database.ExecuteSqlCommand(string.Format("DELETE FROM {0}", table));
                        // Success, so remove table from the list
                        tables.Remove(table);
                    } catch (Exception ex) {
                        // Error, probably due to dependent constraint, save exception for later if needed.                    
                        exception = ex;
                        // Push the table to the back of the queue
                        tables.Remove(table);
                        tables.Add(table);
                    }
                }
                // Error error has occurred, and cannot be resolved by deleting in a different 
                // order, then rethrow the exception and give up.
                if (max <= 0 && exception != null) throw exception;
            
            }
        }
    }
