    public static class TypeMapper
    {
        public static JsonSchemaType Convert(EdmType edmType)
        {
            switch (edmType.BuiltInTypeKind )
            {
                case BuiltInTypeKind.EnumType:
                    return JsonSchemaType.String;
                case BuiltInTypeKind.ComplexType:
                    return JsonSchemaType.Object;
                case BuiltInTypeKind.PrimitiveType:
                    return GetPrimitiveType(edmType);
                default:
                    return JsonSchemaType.Null;
            }
        }
        private static JsonSchemaType GetPrimitiveType(EdmType edmType)
        {
            switch (edmType.Name)
            {
                case "String":
                case "Guid":
                case "DateTime":
                    return JsonSchemaType.String;
                case "Int32":
                    return JsonSchemaType.Integer;
                case "Single":
                case "Double":
                    return JsonSchemaType.Float;
                default:
                    return JsonSchemaType.Null;
            }
        }
    }
