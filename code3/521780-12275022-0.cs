            CodeCompileUnit compileUnit = new CodeCompileUnit();
            CodeNamespace sampleNamespace = new CodeNamespace("Sample");
            CodeTypeDeclaration sampleClass = new CodeTypeDeclaration("SampleClass");
            sampleClass.IsClass = true;
            sampleClass.Members.Add(new CodeMemberField(typeof(Int32), "_sampleField"));
            CodeMemberProperty prop = new CodeMemberProperty();
            prop.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            prop.Name = "SampleProp";
            prop.HasGet = true;
            prop.Type = new CodeTypeReference(typeof(System.Int32));
            prop.GetStatements.Add(new CodeMethodReturnStatement(
        new CodeFieldReferenceExpression(
        new CodeThisReferenceExpression(), "_sampleField")));
            sampleClass.Members.Add(prop);
            sampleNamespace.Types.Add(sampleClass);
            compileUnit.Namespaces.Add(sampleNamespace);
            using (var fileStream = new StreamWriter(File.Create("outputfile.cs")))
            {
                var provider = new Microsoft.CSharp.CSharpCodeProvider();
                provider.GenerateCodeFromCompileUnit(compileUnit, fileStream, null);
            }
