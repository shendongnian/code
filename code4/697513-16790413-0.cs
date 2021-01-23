    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    public class Reflection
    {
        public static T CreateObject<T>(string assemblyName, string className)
        {
            Assembly assembly = Assembly.Load(assemblyName);
            return (T)assembly.CreateInstance(className);
        }
    }
