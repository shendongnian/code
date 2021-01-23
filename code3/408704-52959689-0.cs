    public static class DynamicHelper
    {
        // We expect inputs to be of type IDictionary
        public static ExpandoObject MergeDynamic(dynamic Source, dynamic Additional)
        {
            ExpandoObject Result = new ExpandoObject();
            // First copy 'source' to Result
            DynamicIntoExpando(Result, Source);
            // Then copy additional fields, boldy overwriting the source as needed
            DynamicIntoExpando(Result, Additional);
            // Done
            return Result;
        }
        public static void DynamicIntoExpando(ExpandoObject Result, dynamic Source, string Key = null)
        {
            // Cast it for ease of use.
            var R = Result as IDictionary<string, dynamic>;
            if (Source is IDictionary<string, dynamic>)
            {
                var S = Source as IDictionary<string, dynamic>;
                ExpandoObject NewDict = new ExpandoObject();
                if (Key == null)
                {
                    NewDict = Result;
                }
                else if (R.ContainsKey(Key))
                {
                    // Already exists, overwrite
                    NewDict = R[Key];
                }
                var ND = NewDict as IDictionary<string, dynamic>;
                foreach (string key in S.Keys)
                {
                    ExpandoObject NewDictEntry = new ExpandoObject();
                    if (R.ContainsKey(key))
                    {
                        NewDictEntry = Result;
                    }
                    //ExpandoObject NewDictEntry = ND[key];
                    DynamicIntoExpando(NewDictEntry, S[key], key);
                    if(!R.ContainsKey(key)) {
                        ND[key] = ((IDictionary<string, dynamic>)NewDictEntry)[key];
                    }
                }
                if (Key == null)
                {
                    R = NewDict;
                }
                else if (!R.ContainsKey(Key))
                {
                    R.Add(Key, NewDict);
                }
            }
            else if (Source is IList<dynamic>)
            {
                var S = Source as IList<dynamic>;
                List<ExpandoObject> NewList = new List<ExpandoObject>();
                if (Key != null && R.ContainsKey(Key))
                {
                    // Already exists, overwrite
                    NewList = R[Key];
                }
                foreach (dynamic D in S)
                {
                    ExpandoObject ListEntry = new ExpandoObject();
                    DynamicIntoExpando(ListEntry, D);
                    //  in this case we have to compare the ListEntry to existing entries and on
                    NewList.Add(ListEntry);
                }
                if (Key != null && !R.ContainsKey(Key))
                {
                    R[Key] = NewList.Distinct(); 
                }
            }
            else
            {
                R[Key] = Source;
            }
        }
    }
