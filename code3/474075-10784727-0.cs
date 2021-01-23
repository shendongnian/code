    foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
                {
                    if (type.GetInterfaces().Contains(typeof(ISource)) && type.IsInterface == false
                    {
                        sources.Add((ISource)Activator.CreateInstance(type));
                    }
                }
