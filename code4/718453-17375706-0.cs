                List<object> actions = new List<object>();
                Assembly myDll = Assembly.LoadFrom("TestDLL.dll");
                Type[] types = myDll.GetTypes();
    
                for (int i = 0; i < types.Length; i++)
                {
                    Type type = myDll.GetType(types[i].FullName);
                    if (type.GetInterface("TestDLL.Action") != null)
                    {
                        object obj = Activator.CreateInstance(type);
                        if (obj != null)
                            actions.Add(obj);
                    }
                }
    
                foreach (var action in actions)
                {
                    MethodInfo mi = action.GetType().GetMethod("DoAction");
                    mi.Invoke(action, null);
                }
