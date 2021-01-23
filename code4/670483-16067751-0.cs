    class CSharpSerializer
    {
        private readonly Dictionary<string, int> m_locals =
            new Dictionary<string, int>();
        private readonly List<CodeStatement> m_statements =
            new List<CodeStatement>();
        private string GetVariableName(string suggestedName)
        {
            suggestedName = suggestedName.TrimEnd("0123456789".ToCharArray());
            int n;
            if (m_locals.TryGetValue(suggestedName, out n))
            {
                n++;
                m_locals[suggestedName] = n;
                return suggestedName + n;
            }
            m_locals[suggestedName] = 1;
            return suggestedName;
        }
        public string SerializeObject(object obj)
        {
            m_statements.Clear();
            // dynamic used to make the code simpler
            GetExpression((dynamic)obj);
            var compiler = new CSharpCodeProvider();
            var writer = new StringWriter();
            foreach (var statement in m_statements)
            {
                compiler.GenerateCodeFromStatement(
                    statement, writer, new CodeGeneratorOptions());
            }
            return writer.ToString();
        }
        private static CodeExpression GetExpression(int i)
        {
            return new CodePrimitiveExpression(i);
        }
        private static CodeExpression GetExpression(string s)
        {
            return new CodePrimitiveExpression(s);
        }
        private static CodeExpression GetExpression(DateTime dateTime)
        {
            // TODO: handle culture and milliseconds
            return new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression(typeof(Convert)), "ToDateTime",
                new CodePrimitiveExpression(Convert.ToString(dateTime)));
        }
        // and so on for other primitive types
        // and types that require special handling (including arrays)
        private CodeExpression GetExpression(object obj)
        {
            if (obj == null)
                return new CodePrimitiveExpression(null);
            var type = obj.GetType();
            string typeName = type.Name;
            string variable = GetVariableName(
                typeName[0].ToString().ToLower() + typeName.Substring(1));
            m_statements.Add(
                new CodeVariableDeclarationStatement(
                    typeName, variable, new CodeObjectCreateExpression(typeName)));
            foreach (var property in type.GetProperties(
                BindingFlags.Public | BindingFlags.Instance))
            {
                var expression = GetExpression((dynamic)property.GetValue(obj));
                m_statements.Add(
                    new CodeAssignStatement(
                        new CodePropertyReferenceExpression(
                            new CodeVariableReferenceExpression(variable),
                            property.Name),
                        expression));
            }
            return new CodeVariableReferenceExpression(variable);
        }
    }
