    ClrTypeName contractClassAttribute = 
      new ClrTypeName("System.Diagnostics.Contracts.ContractClassAttribute");
    ClrTypeName someGenericClass = new ClrTypeName("System.Collections.Generic.Dictionary`2");
    var module = provider.PsiModule;
    var owner = provider.GetSelectedElement<IClassDeclaration>(true, true);
    var factory = CSharpElementFactory.GetInstance(module);
    var someGenericTypeElement = TypeElementUtil.GetTypeElementByClrName(someGenericClass, module);
    var unknownType = TypeFactory.CreateUnknownType(module);
    var someGenericType = TypeFactory.CreateType(someGenericTypeElement, unknownType, unknownType);
    var contractClassTypeElement = TypeElementUtil.GetTypeElementByClrName(contractClassAttribute, module);
    var attribute = factory.CreateAttribute(contractClassTypeElement, new[] {new AttributeValue(someGenericType)},
                                            EmptyArray<Pair<string, AttributeValue>>.Instance);
    owner.AddAttributeAfter(attribute, null);
