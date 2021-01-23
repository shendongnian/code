        public void ExecuteAssembly(string anAssemblyName)
        {
            Assembly assembly = Assembly.LoadFrom(anAssemblyName);
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsClass)
                {
                    TypeAttributes atts = type.Attributes;
                    if ((atts & TypeAttributes.Sealed) != 0) // identify the static classes
                        ExecuteEverything(type);
                }
            }
        }
        private void ExecuteEverything(Type type)
        {
            // get only the public STATIC properties and methods declared in the type (i.e. not inherited)
            PropertyInfo[] props = type.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            MethodInfo[] meths = type.GetMethods(BindingFlags.Public | BindingFlags.Static 
                | BindingFlags.DeclaredOnly);
            // execute the methods which aren't property accessors (identified by IsSpecialMethod = true)
            foreach (MethodInfo aMeth in meths)
                if (!aMeth.IsSpecialName)
                    Execute(aMeth, type);
            // for each property get the value and recursively execute everything
            foreach (PropertyInfo aProp in props)
            {
                object aValue = aProp.GetValue(type, null);
                if (aValue != null)
                    RecursivelyExecuteEverything(aValue);
            }
        }
        private void RecursivelyExecuteEverything(object aValue)
        {
            Type type = aValue.GetType();
            // get only the public INSTANCE properties and methods declared in the type (i.e. not inherited)
            PropertyInfo[] props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            MethodInfo[] meths = type.GetMethods(BindingFlags.Public | BindingFlags.Instance
                | BindingFlags.DeclaredOnly);
            // execute the methods which aren't property accessors (identified by IsSpecialMethod = true)
            foreach (MethodInfo aMeth in meths)
                if (!aMeth.IsSpecialName)
                    Execute(aMeth, aValue);
            // for each property get the value and recursively execute everything
            foreach (PropertyInfo aProp in props)
            {
                object newValue = aProp.GetValue(aValue, null);
                if (newValue != null)
                    RecursivelyExecuteEverything(newValue);
            }
        }
        private void Execute(MethodInfo aMeth, object anObj)
        {
            // be careful that here you should take care of the parameters. 
            // this version doesn't work for Method2 in Service2, since it 
            // requires an int as parameter
            aMeth.Invoke(anObj, null);
        }
        
