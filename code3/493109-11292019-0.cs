        private static void FilterProperties(object objToEdit)
        {
            Type t = objToEdit.GetType();
            PropertyInfo[] props = t.GetProperties();
            // create fooObj in order to have another instance to test for NotImplemented exceptions 
            // (I do not know whether your getters could have side effects that you prefer to avoid)
            object fooObj = Activator.CreateInstance(t);
            foreach (PropertyInfo pi in props)
            {
                bool filter = false;
                object[] atts = pi.GetCustomAttributes(typeof(ObsoleteAttribute), true);
                if (atts.Length > 0)
                    filter = true;
                else
                {
                    try
                    {
                        object tmp = pi.GetValue(fooObj, null);
                    }
                    catch
                    {
                        filter = true;
                    }
                }
                PropertyDescriptor pd = TypeDescriptor.GetProperties(t)[pi.Name];
                BrowsableAttribute bAtt = (BrowsableAttribute)pd.Attributes[typeof(BrowsableAttribute)];
                FieldInfo fi = bAtt.GetType().GetField("browsable",
                                   System.Reflection.BindingFlags.NonPublic |
                                   System.Reflection.BindingFlags.Instance);
                fi.SetValue(bAtt, !filter);
            }
        }
