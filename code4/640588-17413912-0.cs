    private static void WriteToArrayString(ICollection items)
        {
            var result = new StringBuilder("new []{");
            var index = 0;
            foreach(var value in items)
            {
                if (index == (items.Count - 1))
                {
                    result.Append(string.Concat(value));
                    index++;
                    continue;
                }
                result.Append(string.Concat(value, ','));
                index++;
            }
            result.Append("};");
            Trace.WriteLine(result.ToString());
        }
