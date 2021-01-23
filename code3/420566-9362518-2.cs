     public static class MyCustomListMethod
        {
            public static void Add(this IList<string> list, string item,bool htmlEndode){
                list.Add(System.Web.HttpUtility.HtmlEncode(item));
            }
        }
