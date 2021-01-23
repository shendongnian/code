    using System;
    using System.Linq;
    using System.Reflection;
    
    using Microsoft.WindowsAzure.StorageClient;
    
    public static class DataServiceQueryExtensions
    {
        public static TableServiceContext GetTableServiceContext<TType>(this IQueryable<TType> query)
        {
            var contextField = query.Provider.GetType().GetField("Context", (BindingFlags.Instance | BindingFlags.NonPublic));
            if (contextField == null)
                return null;
            else
                return contextField.GetValue(query.Provider) as TableServiceContext;
        }
    }
 
