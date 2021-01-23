    public override string ToString()
    {
        if (this.count == 0)
        {
            var type = this.GetType().ToString();
            var matches = Regex.Matches(type,
                    @"([a-zA-Z0-9`]*\.{1}[a-zA-Z0-9`]*)*")
                    .Cast<Match>();
            foreach (Match match in matches.Where(m => m.Value != ""))
            {
                var currentType = Type.GetType(match.Value) 
                    ?? Type.GetType(match.Value + "<>");
                type = type.Replace(match.Value, currentType.Name);
            }
            type = type.Replace("`", "");
            return type;
        }
        else
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
                sb.Append(this[i]);
                sb.Append(System.Environment.NewLine);
            }
            return sb.ToString();
        }
    }
