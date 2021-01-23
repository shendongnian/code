    #region << Usings >>
    
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Web.Mvc;
    using System.IO;
    using System.Web.Script.Serialization;
    using System.Globalization;
    
    #endregion
    
    /// <summary>
    /// This class is to ensure we can receive large JSON data from the client because the default is a bit too small.
    /// </summary>
    /// <remarks>This class is from the web.</remarks>
    public sealed class LargeValueProviderFactory : System.Web.Mvc.ValueProviderFactory
    {
    
        #region << Constructors >>
    
        /// <summary>
        /// Default constructor.
        /// </summary>
        public LargeValueProviderFactory()
            : base()
        {
            // Nothing to do
        }
    
        #endregion
    
        #region << GetValueProvider >>
    
        public override System.Web.Mvc.IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException("controllerContext");
            }
    
            object jsonData = GetDeserializedObject(controllerContext);
            if (jsonData == null)
            {
                return null;
            }
    
            Dictionary<string, object> backingStore = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            AddToBackingStore(backingStore, String.Empty, jsonData);
            return new DictionaryValueProvider<object>(backingStore, CultureInfo.CurrentCulture);
        }
    
        #endregion
    
        #region << Helper Methods >>
    
        private static void AddToBackingStore(Dictionary<string, object> backingStore, string prefix, object value)
        {
            IDictionary<string, object> d = value as IDictionary<string, object>;
            if (d != null)
            {
                foreach (KeyValuePair<string, object> entry in d)
                {
                    AddToBackingStore(backingStore, MakePropertyKey(prefix, entry.Key), entry.Value);
                }
                return;
            }
    
            IList l = value as IList;
            if (l != null)
            {
                for (int i = 0; i < l.Count; i++)
                {
                    AddToBackingStore(backingStore, MakeArrayKey(prefix, i), l[i]);
                }
                if (l.Count == 0)
                    backingStore[prefix] = value;
                return;
            }
    
            // primitive
            backingStore[prefix] = value;
        }
    
        private static object GetDeserializedObject(ControllerContext controllerContext)
        {
            
            if (!controllerContext.HttpContext.Request.ContentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
            {
                // not JSON request
                return null;
            }
    
            StreamReader reader = new StreamReader(controllerContext.HttpContext.Request.InputStream);
            string bodyText = reader.ReadToEnd();
            if (String.IsNullOrEmpty(bodyText))
            {
                // no JSON data
                return null;
            }
    
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            object jsonData = serializer.DeserializeObject(bodyText);
            return jsonData;
        }
    
    
        private static string MakeArrayKey(string prefix, int index)
        {
            return prefix + "[" + index.ToString(CultureInfo.InvariantCulture) + "]";
        }
    
        private static string MakePropertyKey(string prefix, string propertyName)
        {
            return (String.IsNullOrEmpty(prefix)) ? propertyName : prefix + "." + propertyName;
        }
    
        #endregion
    
    }
