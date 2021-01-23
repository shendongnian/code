    /// <summary>
        /// Returns a string from a column
        /// This extension exists because SQLite doesn't recognize null as a valid string but C# does
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Column"></param>
        /// <returns></returns>
        public static String xGetString(this System.Data.Common.DbDataReader Source, Int32 Column)
        {
            if (Source.IsDBNull(Column))
                return null;
            if (Source.GetFieldType(Column) != typeof(String))
                throw new Core.DatabaseException(
                    String.Format("Column `{0}` ({1}) is not of type String. Type is {2}.",
                    Source.GetName(Column), Column, Source.GetFieldType(Column).Name));
            return Source.GetString(Column);
        }
