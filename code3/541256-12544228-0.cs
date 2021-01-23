    public static string DotFormatToRowKey(this string dotFormatRowKey)
            {
                Regex validationRegex = new Regex(@"\d.\d");
                if (!validationRegex.Match(dotFormatRowKey).Length.Equals(dotFormatRowKey.Length)) throw new FormatException("Input string does not support format x.x where x is number");
                
                var splits = dotFormatRowKey.Split('.')
                    .Select(x => String.Format("{0:d2}", Int32.Parse(x)))
                    .ToList();
                return String.Join(String.Empty, splits.ToArray());
            }
