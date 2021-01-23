        public class JsonHelper
    {
        /// <summary>
        /// Parses the JSON.
        /// Thanks to http://stackoverflow.com/questions/14967618/deserialize-json-to-class-manually-with-reflection
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns></returns>
        public static Dictionary<string, object> DeserializeJson(string json)
        {
            int end;
            return DeserializeJson(json, 0, out end);
        }
        /// <summary>
        /// Parses the JSON.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns></returns>
        private static Dictionary<string, object> DeserializeJson(string json, int start, out int end)
        {
            var dict = new Dictionary<string, object>();
            var escbegin = false;
            var escend = false;
            var inquotes = false;
            string key = null;
            var sb = new StringBuilder();
            List<object> arraylist = null;
            var regex = new Regex(@"\\u([0-9a-z]{4})", RegexOptions.IgnoreCase);
            var autoKey = 0;
            var inSingleQuotes = false;
            var inDoubleQuotes = false;
            for (var i = start; i < json.Length; i++)
            {
                var c = json[i];
                if (c == '\\') escbegin = !escbegin;
                if (!escbegin)
                {
                    if (c == '"' && !inSingleQuotes)
                    {
                        inDoubleQuotes = !inDoubleQuotes;
                        inquotes = !inquotes;
                        if (!inquotes && arraylist != null)
                        {
                            arraylist.Add(DecodeString(regex, sb.ToString()));
                            sb.Length = 0;
                        }
                        continue;
                    }
                    if (c == '\'' && !inDoubleQuotes)
                    {
                        inSingleQuotes = !inSingleQuotes;
                        inquotes = !inquotes;
                        if (!inquotes && arraylist != null)
                        {
                            arraylist.Add(DecodeString(regex, sb.ToString()));
                            sb.Length = 0;
                        }
                        continue;
                    }
                    if (!inquotes)
                    {
                        switch (c)
                        {
                            case '{':
                                if (i != start)
                                {
                                    int cend;
                                    var child = DeserializeJson(json, i, out cend);
                                    if (arraylist != null)
                                    {
                                        arraylist.Add(child);
                                    }
                                    else
                                    {
                                        dict.Add(key.Trim(), child);
                                        key = null;
                                    }
                                    i = cend;
                                }
                                continue;
                            case '}':
                                end = i;
                                if (key != null)
                                {
                                    if (arraylist != null) dict.Add(key.Trim(), arraylist);
                                    else dict.Add(key.Trim(), DecodeString(regex, sb.ToString().Trim()));
                                }
                                return dict;
                            case '[':
                                arraylist = new List<object>();
                                continue;
                            case ']':
                                if (key == null)
                                {
                                    key = "array" + autoKey;
                                    autoKey++;
                                }
                                if (arraylist != null && sb.Length > 0)
                                {
                                    arraylist.Add(sb.ToString());
                                    sb.Length = 0;
                                }
                                dict.Add(key.Trim(), arraylist);
                                arraylist = null;
                                key = null;
                                continue;
                            case ',':
                                if (arraylist == null && key != null)
                                {
                                    dict.Add(key.Trim(), DecodeString(regex, sb.ToString().Trim()));
                                    key = null;
                                    sb.Length = 0;
                                }
                                if (arraylist != null && sb.Length > 0)
                                {
                                    arraylist.Add(sb.ToString());
                                    sb.Length = 0;
                                }
                                continue;
                            case ':':
                                key = DecodeString(regex, sb.ToString());
                                sb.Length = 0;
                                continue;
                        }
                    }
                }
                sb.Append(c);
                if (escend) escbegin = false;
                escend = escbegin;
            }
            end = json.Length - 1;
            return dict; // theoretically shouldn't ever get here
        }
        /// <summary>
        /// Decodes the string.
        /// </summary>
        /// <param name="regex">The regex.</param>
        /// <param name="str">The STR.</param>
        /// <returns></returns>
        private static string DecodeString(Regex regex, string str)
        {
            return
                Regex.Unescape(regex.Replace(str,
                    match =>
                        char.ConvertFromUtf32(Int32.Parse(match.Groups[1].Value,
                            System.Globalization.NumberStyles
                                .HexNumber))));
        }
        /// <summary>
        /// Returns true if string has an "appearance" of being JSON-like
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsJson(string input)
        {
            input = input.Trim();
            return input.StartsWith("{") && input.EndsWith("}")
                   || input.StartsWith("[") && input.EndsWith("]");
        }
    }
