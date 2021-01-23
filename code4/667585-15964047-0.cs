    var entityBaseType = document.Project.GetCompilation(cancellationToken).GetTypeByMetadataName("FullyQualifiedTypeName.EntityBase");
    var typeInfo = document.GetSemanticModel(cancellationToken).GetTypeInfo(node);
    if (typeInfo.Type.BaseType.Equals(entityBaseType))
    {
        return new CodeIssue(...);
    }
    return null;
