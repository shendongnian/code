    var attribute = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false).Cast<AssemblyDescriptionAttribute>().FirstOrDefault();
                if (attribute!=null)
                {
                    Console.WriteLine(attribute.Description);
                }
