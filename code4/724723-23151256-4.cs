       public static string OxfordAnd(this IEnumerable<string> enumerable)
            {
                if (enumerable == null) return null;
    
                var list = enumerable.ToList();
    
                string reditum;
    
                switch (list.Count)
                {
                    case 1:
                        reditum = list.First();
                        break;
                    case 2:
                        reditum = JoinWithSpace(list);
                        break;
                    default:
                        {
                            var delimited = JoinWithComma(list.Take(list.Count - 1));
    
                            reditum = $"{delimited}, and {list.LastOrDefault()}";
                        }
                        break;
                }
    
                return reditum;
            }
