        public Type GetGenericTypeOf(string assemblyPath, string genericClass, string itemQualifiedClass)
        {
            string typString = String.Format("{0}`1[[{1}]]",genericClass,itemQualifiedClass)
            var asmbly = System.Reflection.Assembly.LoadFrom(assemblyPath); //open assembly
            return asmbly.GetType(typString, true, true); //throws error, not case sensitive
        }
