    public static class ParameterExtensions
    {
        private static System.Reflection.FieldInfo InitFieldInfo()
        {
            System.Type t = typeof(System.Collections.Specialized.NameObjectCollectionBase);
            System.Reflection.FieldInfo fi = t.GetField("_entriesTable", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if(fi == null) // Mono
                fi = t.GetField("m_ItemsContainer", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            return fi;
        }
        private static System.Reflection.FieldInfo m_fi = InitFieldInfo();
        public static bool Contains(this System.Collections.Specialized.NameValueCollection nvc, string key)
        {
            //System.Collections.Specialized.NameValueCollection nvc = new System.Collections.Specialized.NameValueCollection();
            //nvc.Add("hello", "world");
            //nvc.Add("test", "case");
            // The Hashtable is case-INsensitive
            System.Collections.Hashtable ent = (System.Collections.Hashtable)m_fi.GetValue(nvc);
            return ent.ContainsKey(key);
        }
    }
