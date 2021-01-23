            AppDomain domain = AppDomain.CurrentDomain;
            domain.SetData("testKey", "testValue");
            FieldInfo[] fieldInfoArr = domain.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (FieldInfo fieldInfo in fieldInfoArr)
            {
                if (string.Compare(fieldInfo.Name, "_LocalStore", true) != 0)
                    continue;
                Object value = fieldInfo.GetValue(domain);
                if (!(value is Dictionary<string,object[]>))
                    return;
                Dictionary<string, object[]> localStore = (Dictionary<string, object[]>)value;
                foreach (var item in localStore)
                {
                    Object[] values = (Object[])item.Value;
                    foreach (var val in values)
                    {
                        if (val == null)
                            continue;
                        Console.WriteLine(item.Key + " " + val.ToString());
                    }
                }
                
            }
