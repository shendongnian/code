    var typesToDo = from t in Assembly.GetAssembly(typeof(FrameworkElement)).GetTypes()
                    where t.IsSubclassOf(typeof(FrameworkElement)) 
                            && t.IsPublic 
                            && t.GetEvents().Any()
                    select t;
