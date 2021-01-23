	static string GetTypeName(Type type)
	{
		var codeDomProvider = CodeDomProvider.CreateProvider("C#");
		var typeReferenceExpression = new CodeTypeReferenceExpression(new CodeTypeReference(type));
		using (var writer = new StringWriter())
		{
			codeDomProvider.GenerateCodeFromExpression(typeReferenceExpression, writer, new CodeGeneratorOptions());
			return writer.GetStringBuilder().ToString();
		}
	}
