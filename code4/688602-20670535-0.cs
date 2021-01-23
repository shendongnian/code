     public static Dictionary<string, string> ToDictionary(this NameValueCollection nvc) {
        return nvc.AllKeys.ToDictionary(k => k, k => nvc[k]);
     }
     //example
     var dictionary = nvc.ToDictionary();
