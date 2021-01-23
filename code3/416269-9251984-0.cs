    public static void SM_Dump_TruncStrings(ref List<myDataType> dump, int maxLength, bool addEllipses)
        {
            foreach (var sm in dump)
            {
                PropertyInfo[] infos = sm.GetType().GetProperties();
                foreach (var info in infos)
                {
                    if (info.PropertyType == typeof(string))
                    {
                        var origValue = info.GetValue(sm, null) as string;
                        if (origValue != null && origValue.Length > maxLength)
                        {
                            var newVal = origValue.Substring(0, maxLength);
                            if (addEllipses)
                                newVal += "...";
                            info.SetValue(sm, newVal, null);
                        }
                    }
                }
            }
        }
