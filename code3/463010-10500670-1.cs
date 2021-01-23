    cb.RegisterAssemblyTypes(assembly).Where(t =>
                {
                    var implementations = t.GetInterfaces();
                    if (implementations.Length > 0)
                    {
                        var iface = implementations[0];
                        var implementers = assembly.GetTypes().Where(t2 => t2.GetInterfaces().Contains(iface));
                        return implementers.Count() == 1;
                    }
                    return false;
                }).As(t => t.GetInterfaces()[0]);
