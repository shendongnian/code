    public class SupportedObjectsResults
    {
        public List<object> SupportedObjects { get; private set; }
        public List<object> UnsupportedObjects { get; private set; }
    
        public SupportedObjectsResults(List<object> supportedObjects, List<object> unsupportedObjects)
        {
            this.SupportedObjects = supportedObjects;
            this.UnsupportedObjects = unsupportedObjects;
        }
    }
    public static class SupportedTypeHelper
    {
        public static SupportedObjectsResults GetSupportedTypes(params object[] values)
        {
            List<object> supportedObjects = new List<object>();
            List<object> unsupportedObjects = new List<object>();
    
            foreach(object value in values)
            {
                if (CheckIsSupported(value))
                    supportedObjects.Add(value);
                else
                    unsupportedObjects.Add(value);
            }
    
            return new SupportedObjectsResults(supportedObjects, unsupportedObjects);
        }
    
        private static bool CheckIsSupported(object underlyingValue)
        {
            return (underlyingValue is string ||
                    underlyingValue is bool
                    );
        }
    }
