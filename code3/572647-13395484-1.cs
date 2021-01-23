        static readonly PropertyInfo GetResProp = typeof(XmlSchemaException)
            .GetProperty("GetRes", BindingFlags.NonPublic | BindingFlags.Instance);
        static bool IsUnparsedEntityReferenceError_BasedOnReflection(
            XmlSchemaException error)
        {
            return error != null && GetResProp != null && 
                "Sch_UnparsedEntityRef".Equals(GetResProp.GetValue(error, null));
        }
