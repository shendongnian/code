    public static class MyExtension
    {
        public static string ArrayToString(this Array arr)
        {
            List<object> lst = new List<object>();
            object[] obj = new object[arr.Length];
            Array.Copy(arr, obj, arr.Length);
    
            lst.AddRange(obj);
            return string.Join(",", lst.ToArray());
        }
    }
