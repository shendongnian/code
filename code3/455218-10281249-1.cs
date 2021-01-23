    CustomAttribute attribute = new CustomAttribute(attributeConstructor);
    attribute.ConstructorArguments.Add(
            new CustomAttributeArgument(
                module.TypeSystem.String, "Foo"));
    attribute.ConstructorArguments.Add(
            new CustomAttributeArgument(
                module.TypeSystem.String, "Bar"));
