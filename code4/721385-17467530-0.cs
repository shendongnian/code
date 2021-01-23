    static string MyJoin(Dictionary<string,bool> dict)
            {
                var dictTrue = dict.Where(e=>e.Value);
                if(dictTrue.Count()==0) return string.Empty;
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Join(", ",dictTrue.Select(e=>e.Key).Take(dictTrue.Count()-1)));
                sb.Append(" and ");
                sb.Append(dictTrue.Last().Key);
                return sb.ToString();
            }
