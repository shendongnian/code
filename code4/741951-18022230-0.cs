    using System;
    using System.CodeDom;
    using System.CodeDom.Compiler;
    using System.IO;
    namespace CustomTool
    {
        public static class StringExtensions
        {
            public static String ToLiteral(this String input)
            {
                using (var writer = new StringWriter())
                {
                    using (var provider = CodeDomProvider.CreateProvider("CSharp"))
                    {
                        provider.GenerateCodeFromExpression(new CodePrimitiveExpression(input), writer, null);
                        return writer.ToString();
                    }
                }
            }
        }
    }
