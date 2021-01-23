       public static SortedList<int, string> GetEnumDataSource<T>()
        {
            Type myEnumType = typeof(T);
            SortedList<int, string> returnCollection = new SortedList<int, string>();
            try
            {
                if (myEnumType.BaseType == typeof(Enum))
                {
                    string[] enumNames = Enum.GetNames(myEnumType);
                    int enumLength = enumNames.Length - 1;
                    for (int i = 0; i <= enumLength; i++)
                    {
                        returnCollection.Add(Convert.ToInt32(Enum.Parse(myEnumType, enumNames[i])), enumNames[i]);
                    }
                }
            }
            catch (Exception exception1)
            {
    
                return null;
            }
            return returnCollection;
        }
