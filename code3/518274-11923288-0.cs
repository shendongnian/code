    public static string IndentCSharpCode(string code)
	{
		const string INDENT_STEP = "    ";
		if (string.IsNullOrWhiteSpace(code))
		{
			return code;
		}
		var result = new StringBuilder();
		var indent = string.Empty;
		var lineContent = false;
		var stringDefinition = false;
		for (var i = 0; i < code.Length; i++)
		{
			var ch = code[i];
			if (ch == '"' && !stringDefinition)
			{
				result.Append(ch);
				stringDefinition = true;
				continue;
			}
			if (ch == '"' && stringDefinition)
			{
				result.Append(ch);
				stringDefinition = false;
				continue;
			}
			if (stringDefinition)
			{
				result.Append(ch);
				continue;
			}
			if (ch == '{' && !stringDefinition)
			{
				if (lineContent)
				{
					result.AppendLine();
				}
				result.Append(indent).Append("{");
				if (lineContent)
				{
					result.AppendLine();
				}
				indent += INDENT_STEP;
				lineContent = false;
				continue;
			}
			if (ch == '}' && !stringDefinition)
			{
				if (indent.Length != 0)
				{
					indent = indent.Substring(0, indent.Length - INDENT_STEP.Length);
				}
				if (lineContent)
				{
					result.AppendLine();
				}
				result.Append(indent).Append("}");
				if (lineContent)
				{
					result.AppendLine();
				}
				lineContent = false;
				continue;
			}
			if (ch == '\r')
			{
				continue;
			}
			if ((ch == ' ' || ch == '\t') && !lineContent)
			{
				continue;
			}
			if (ch == '\n')
			{
				lineContent = false;
				result.AppendLine();
				continue;
			}
			if (!lineContent)
			{
				result.Append(indent);
				lineContent = true;
			}
			result.Append(ch);
		}
		return result.ToString();
	}
