    using System;
    using System.Collections.Generic;
    using DataAccess.Core.DataInterfaces;
    using DataAccess.Core.Utils;
    namespace StackOverflowExample
    {
    	public class SimpleIoC<T>
    	{
            public T getInstance()
            {
                return getInstance(null);
            }
		
            public T getInstance(object[] initializationParameters)
            {
                Type type = Activator.CreateInstance(typeof(T), initializationParameters).GetType();
                // Any special initialization for an object should be placed in a case statement
                // using that object's type name
                switch (type.ToString())
                {
                    // Example
                    //case "DataAccess.Data.ApplicantDao":
                    //    // - Do pre-instanciation initialization stuff here -
                    //    return (T)Activator.CreateInstance(typeof(T), initializationParameters);
                    default:
                        return (T)Activator.CreateInstance(typeof(T), initializationParameters);
                }
            }
    	}
    }
