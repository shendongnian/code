	string GetSourceCode(Type t)
	{
		var sb = new StringBuilder();
		sb.AppendFormat("public class {0}\n{{\n", t.Name);
		
		foreach (var field in t.GetFields())
		{
			sb.AppendFormat("    public {0} {1};\n",
				field.FieldType.Name,
				field.Name);
		}
		
		foreach (var prop in t.GetProperties())
		{
			sb.AppendFormat("    public {0} {1} {{{2}{3}}}\n",
				prop.PropertyType.Name,
				prop.Name,
				prop.CanRead ? " get;" : "",
				prop.CanWrite ? " set; " : " ");
		}
		
		sb.AppendLine("}");
		return sb.ToString();
	} 
