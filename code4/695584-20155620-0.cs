        public static EdmType GetStorePrimitiveType(DbModel model, PrimitiveTypeKind typeKind)
        {
            return model.ProviderManifest.GetStoreType(TypeUsage.CreateDefaultTypeUsage(
                PrimitiveType.GetEdmPrimitiveType(typeKind))).EdmType;
        }
