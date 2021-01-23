         DataSet xmlDS = new DataSet();
         xmlDS.ReadXml(filename);
         GetSpecifiedValuesInDataSet(xmlDS);
         DataTable table = xmlDS.Tables["Specific"];
         foreach(ArrayOfSubClass array in this.Items)
         {
            foreach(SubClass sub in array)
            {
               foreach(Specific specific in sub)
               {
                  Type specificType = specific.GetType();
                  DataRow modelRow = null;
                  foreach(DataRow row in table.Rows)
                  {
                     if(row["Par1"].ToString().Equals(specific.Par1.ToString()))
                     {
                        modelRow = row;
                        break;
                     }
                  }
                  if(modelRow != null)
                  {
                     foreach(PropertyInfo propSpecific in specificType.GetProperties())
                     {
                        string propertyName = propSpecific .Name;
                        foreach(DataColumn col in table.Columns)
                        {
                           if(col.ColumnName.Equals(propertyName))
                           {
                              if(!string.IsNullOrEmpty(modelRow[propertyName].ToString()))
                              {
                                 object value = Convert.ChangeType(modelRow[propertyName], propSpecific.PropertyType);
                                 propSpecific.SetValue(modelProd, value, null);
                              }
                           }
                        }
                     }
                  }
               }
            }
         }
