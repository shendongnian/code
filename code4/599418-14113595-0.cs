    public class DataAccess
    {
        /// <summary>
        /// Hydrates the collection of the type passes in.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL.</param>
        /// <param name="connection">The connection.</param>
        /// <returns>List{``0}.</returns>
        public List<T> List<T>(string sql, string connection) where T: new()
        {
            List<T> items = new List<T>();
            using (SqlCommand command = new SqlCommand(sql, new SqlConnection(connection)))
            {
                string[] columns = GetColumnsNames<T>();
                var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    T item = new T();
                    foreach (var column in columns)
                    {
                        object val = reader.GetValue(reader.GetOrdinal(column));
                        SetValue(item, val, column);
                    }
                    items.Add(item);
                }
                command.Connection.Close();
            }
            return items;
        }
        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <param name="value">The value.</param>
        /// <param name="column">The column.</param>
        private void SetValue<T>(T item, object value, string column)
        {
            var property = item.GetType().GetProperty(column);
            property.SetValue(item, value, null);
        }
        /// <summary>
        /// Gets the columns names.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>System.String[][].</returns>
        private string[] GetColumnsNames<T>() where T : new()
        {
            T item = new T();
            return (from i in item.GetType().GetProperties()
                    select i.Name).ToArray();
        }
    }
