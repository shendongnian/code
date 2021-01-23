    using System;
    using System.Data;
    
    public static class DataAccess
    {
        public static T GetValueOrDefault<T>(DataRow row, string fieldName)
        {
            if (!row.Table.Columns.Contains(fieldName))
            {
                throw new ArgumentException(
                    string.Format("The given DataRow does not contain a field with the name \"{0}\".", fieldName));
            }
            else if (row[fieldName].Equals(DBNull.Value))
            {
                return default(T);
            }
            return row.Field<T>(fieldName);
        }
    }
