    private void SerializePerinatalModel<T>(IDictionary<string, object> dataModel, T perinatalModel)
        {
            Type sourceType = typeof(T);
            foreach (PropertyInfo propInfo in (sourceType.GetProperties()))
            {
                if (dataModel.ContainsKey(propInfo.Name))
                {
                    //  if an empty string has been returned don't change the value
                    if (dataModel[propInfo.Name].ToNullSafeString() != String.Empty)
                    {
                        try
                        {
                            Type localType = propInfo.PropertyType;
                            localType = Nullable.GetUnderlyingType(localType) ?? localType;
                            propInfo.SetValue(perinatalModel, Convert.ChangeType(dataModel[propInfo.Name], localType), null); 
                        }
                        catch (Exception e)
                        {
                            //  ToDo: log update value errors
                        }
                    }
                }
            }
        }
