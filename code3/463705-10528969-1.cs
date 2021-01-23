    private string FormatEval(Match m)
    {
        int val = -1;
        string formatted = m.Value;
        if (int.TryParse(m.Groups["index"].Value, out val))
            formatted = val == 0 ? this.FirstValue : "{" + (val - 1).ToString() + "}";
        return formatted;
    }
    
    public string GetMessage(params object[] otherValues)
    {
        string format = Regex.Replace(this.Message, @"\{(?<index>\d+)\}", FormatEval);
        return string.Format(format, otherValues);
    }
