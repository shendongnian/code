    public static long Add<T>(DBData[] UserData)
        {
            SortedDictionary<string, DBData> Data = new SortedDictionary<string, DBData>();
            foreach (DBData d in UserData)
            {
                Data.Add(d.FieldName, d);
            }
            MethodInfo m = typeof(T).GetMethod("Validate");
            bool r = (bool)m.Invoke(null, new object[] { Data, OperationMode.Add });
            if (r)
            {
                return DBUtility.Insert(typeof(T).Name, VSCommon.Serialise(Data));
            }
            else
            {
                return -1;
            }
        }
