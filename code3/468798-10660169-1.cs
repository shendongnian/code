        var jss = new JavaScriptSerializer();
        var o = return new DynamicJsonObject(jss.Deserialize<Dictionary<string, object>>(json));
        
        var additionalParameters = new Dictionary<string, string>();
        BuildVariablesList(o.GetInternalDictionary(), "", additionalParameters);
        private static string AppendToPathString (string path, object part )
        {
            return path.Trim().Length == 0 ? part.ToString() : path + '.' + part;
        }
        public static void BuildVariablesList(object obj, string path, Dictionary<string, string> result)
        {
            if ( obj is ArrayList)
            {
                var arrayObj = obj as ArrayList;
                for (var i = 0; i<arrayObj.Count; i++ )
                {
                    BuildVariablesList(arrayObj[i], AppendToPathString(path,i), result);
                }
            }else if ( obj is Dictionary<string, object>)
            {
                var dictObject = obj as Dictionary<string, object>;
                foreach (var entry in dictObject)
                {
                    if (entry.Value is String && (path.Trim().Length > 0 || !ReservedFieldNames.Contains( entry.Key.ToLower())))
                    {
                        result.Add(AppendToPathString(path,entry.Key), entry.Value as String);
                    }
                    else if (entry.Value is Dictionary<string, object>)
                    {
                        BuildVariablesList(entry.Value as Dictionary<string, object>, AppendToPathString(path, entry.Key), result);
                    }
                    else if (entry.Value is ArrayList)
                    {
                        BuildVariablesList(entry.Value as ArrayList, AppendToPathString(path, entry.Key), result);
                    }
                }
            }            
        }
