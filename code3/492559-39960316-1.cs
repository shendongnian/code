    public object SqlToSingleObject(string sSql, object o)
    {
        MySql.Data.MySqlClient.MySqlDataReader oRead;
        using (ConnectionHelper oDb = new ConnectionHelper())
        {
            oRead = oDb.Execute(sSql);
            if (oRead.Read())
            {
                for (int i = 0; i < oRead.FieldCount; i++)
                {
                    System.Reflection.PropertyInfo propertyInfo = o.GetType().GetProperty(oRead.GetName(i));
                    propertyInfo.SetValue(o, Convert.ChangeType(oRead[i], propertyInfo.PropertyType), null);
                }
                return o;
            }
            else
            {
                return null;
            }
        }
    }
