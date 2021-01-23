            List<String> Dlls = new List<string>();
            List<String> Namespaces = new List<string>();
            List<String> Methods = new List<string>();
            foreach (var Assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (!Dlls.Contains(Assembly.GetName().Name))
                    Dlls.Add(Assembly.GetName().Name);
                foreach (var Type in Assembly.GetTypes())
                {
                    if (!Namespaces.Contains(Type.Namespace))
                        Namespaces.Add(Type.Namespace);
                    foreach(var Method in Type.GetMethods())
                    {
                        Methods.Add(String.Format("{0}.{1}", Type.Name, Method.Name));
                    }
                }
                
            }
