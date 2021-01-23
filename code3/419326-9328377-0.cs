        public static string[] GetCSVsFromArray(int[] array, int csvLimit)
        {
            List<string> parts = new List<string>();
            StringBuilder sb = new StringBuilder();
            foreach (string intId in array.Select(id => id.ToString()))
            {
                if (sb.Length + intId.Length < csvLimit)
                    sb.Append(intId).Append(",");
                else
                {
                    if (sb.Length > 0)
                        sb.Length--; parts.Add(sb.ToString()); sb.Length = 0;
                }
            }
            return parts.ToArray();
        }
