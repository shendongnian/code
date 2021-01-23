        private Dictionary<string, object> FillDictionaryWithReaderValues(List<string> propertiesOfAllEntities, IDataReader reader)
        {
 
            Dictionary<string, object> propertyResultList = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);
            for (int i = 0; i < reader.FieldCount; i++)
            {
                string readerFieldName = reader.GetName(i);
                //Whether propertiesOfAllEntities.Contains the property
                if (propertiesOfAllEntities.FindIndex(x => x.Equals(readerFieldName, StringComparison.OrdinalIgnoreCase)) != -1)
                {
                    propertyResultList.Add(readerFieldName, reader[i]);
                }
 
            }
 
            return propertyResultList;
        }
 
