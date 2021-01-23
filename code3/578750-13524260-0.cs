        namespace Test.Utility
        {
            public class CommonUtility
            {
                public static JavaScriptSerializer javaScriptSerializer = new    JavaScriptSerializer();
                public static string SerializeJson(object o)
                {
                    return javaScriptSerializer.Serialize(o);
                }
            }
        }
