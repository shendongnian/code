          public static int CreateEmptyRow(string tableName)
        {
            var tableType = Type.GetType(tableName);
            if (tableType == null)
                throw new TypeLoadException("Dumbass. That table doesn't exist");
            var instance = Activator.CreateInstance(tableType) as ITable;
            if (instance == null)
                throw new TypeLoadException("Idiot. That type isn't a table");
            return instance.Insert(new DataRow());
        }
        public static List<DataRow> Select(List<int> ids, string tableName)
        {
            var tableType = Type.GetType(tableName);
            if (tableType == null)
                throw new TypeLoadException("Dumbass. That table doesn't exist");
            var instance = Activator.CreateInstance(tableType) as ITable;
            if (instance == null)
                throw new TypeLoadException("Idiot. That type isn't a table");
            return instance.Select(ids).ToList();
        }
