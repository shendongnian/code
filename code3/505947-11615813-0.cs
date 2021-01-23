    namespace SchemaImport
    {
        public class ADODBSchemaImporterExtension : SchemaImporterExtension
        {
            public override CodeExpression ImportDefaultValue(string value, string type)
            {
                return new CodeTypeReferenceExpression(type);
            }
            public override string ImportSchemaType(XmlSchemaType type,
                XmlSchemaObject context, XmlSchemas schemas, XmlSchemaImporter importer,
                CodeCompileUnit compileUnit, CodeNamespace codeNamespace,
                CodeGenerationOptions options, CodeDomProvider codeGenerator)
            {
            return null;
            }
            public override string ImportSchemaType(string name, 
                string ns, XmlSchemaObject context, XmlSchemas schemas, XmlSchemaImporter importer, 
                CodeCompileUnit compileUnit, CodeNamespace mainNamespace, 
                CodeGenerationOptions options, CodeDomProvider codeProvider)
            {
                if (name.StartsWith("ADODB."))
                {
                    compileUnit.ReferencedAssemblies.Add("adodb.dll");
                    mainNamespace.Imports.Add(new CodeNamespaceImport("ADODB"));
                    return name.Substring(name.IndexOf(".") + 1);
                }
                return null;
            }
        }
    }
