    CodeTypeDeclaration exampleClass = new CodeTypeDeclaration("GeneratedClass");
    CodeMemberField constant = new CodeMemberField(new CodeTypeReference(typeof(System.UInt32)), "addressFilteresErrorCounters");
    constant.Attributes = MemberAttributes.Const;
    constant.InitExpression = new CodePrimitiveExpression(0x0000AE77);
    exampleClass.Members.Add(constant);
