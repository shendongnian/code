            Assembly objAssembly = Assembly.LoadFrom("Company.dll");
            Type objAssemblyType = objAssembly.GetType();
           
            foreach (Type type in objAssembly.GetTypes())
            {
                if (type.IsClass == true)
                {
                    var classInstance = objAssembly.CreateInstance(type.ToString()) as IPlugin;
                    lblFullName.Text = classInstance.FullName("Mr. ");
                     
                }
            }
