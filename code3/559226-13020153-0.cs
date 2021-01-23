    private void AppendAttributes(StringBuilder sb)
    {
        foreach (KeyValuePair<string, string> current in this.Attributes)
        {
            string key = current.Key;
            if (!string.Equals(key, "id", StringComparison.Ordinal) || !string.IsNullOrEmpty(current.Value))
            {
                string value = HttpUtility.HtmlAttributeEncode(current.Value);
                sb.Append(' ').Append(key).Append("=\"").Append(value).Append('"');
            }
        }
    }
