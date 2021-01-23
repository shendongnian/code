        /// <summary>
        /// With a data row, create an object and populate it with data
        /// </summary>
        private object CreateObject(List<DataCell> pRow, string objectName)
        {
            Type type = Type.GetType(objectName);
            if (type == null)
                throw new Exception(String.Format("Could not create type {0}", objectName));
            object obj = Activator.CreateInstance(type);
            foreach (DataCell cell in pRow)
            {           
                propagateToProperty(obj, *propertypath*, cell.CellValue);
            }
            return obj;
        }
       public static void propagateToProperty(object pObject, string pPropertyPath, object pValue)
            {
                Type t = pObject.GetType();
                object currentO = pObject;
                string[] path = pPropertyPath.Split('.');
                for (byte i = 0; i < path.Length; i++)
                {
                    //go through object hierarchy
                    PropertyInfo pi = t.GetProperty(path[i]);
                    if (pi == null)
                        throw new Exception(String.Format("No property {0} on type {1}", path[i], pObject.GetType()));
    
                    //an object in the property path
                    if (i != path.Length - 1)
                    {
                        t = pi.PropertyType;
                        object childObject = pi.GetValue(currentO, null);
                        if (childObject == null)
                        {
                            childObject = Activator.CreateInstance(t);
                            pi.SetValue(currentO, childObject, null);
                        }
                        currentO = childObject;
        
                    //the target property
                    else
                    {
                        if (pi.PropertyType.IsEnum && pValue.GetType() != pi.PropertyType)
                            pValue = Enum.Parse(pi.PropertyType, pValue.ToString());
                        if (pi.PropertyType == typeof(Guid) && pValue.GetType() != pi.PropertyType)
                            pValue = new Guid(pValue.ToString());
                        if (pi.PropertyType == typeof(char))
                            if (pValue.ToString().Length == 0)
                                pValue = ' ';
                            else
                                pValue = pValue.ToString()[0];
    
                        pi.SetValue(currentO, pValue, null);
                    }
                }
            }
