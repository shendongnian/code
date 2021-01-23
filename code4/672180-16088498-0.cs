    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
     
    namespace Example
    {
    public static class JavascriptSerializator
    {
        /// <summary>
        /// Serializes object to JSON from Microsoft
        /// </summary>
        /// <param name="objectForSerialization"></param>
        /// <returns></returns>
        public static string SerializeMJSON(this object objectForSerialization)
        {
            try
            {
                System.Web.Script.Serialization.JavaScriptSerializer s = new System.Web.Script.Serialization.JavaScriptSerializer();
                return s.Serialize(objectForSerialization);
            }
            catch (Exception ex)
            {
                /// Handle exception and throw it ...
            }
        }
        /// <summary>
        /// Deserializes object from Microsoft JSON string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T DeserializeMJSON<T>(this string str)
        {
            try
            {
                System.Web.Script.Serialization.JavaScriptSerializer s = new System.Web.Script.Serialization.JavaScriptSerializer();
                return s.Deserialize<T>(str);
            }
            catch (Exception ex)
            {
                //// Handle the exception here...
            }
        }
    }
}
