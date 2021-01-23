     public static string phpStringArray(Dictionary<string, string> arr)
     {
         StringBuilder sb = new StringBuilder("a:")
             .Append(arr.Count).Append(":{");
         foreach (string key in arr.Keys)
         {
             sb.AppendFormat("s:{0}:\"{1}\";s:{2}:\"{3}\";",
                 key.Length, key, arr[key].Length, arr[key]);
         }
         return sb.Append('}').ToString();
     }
