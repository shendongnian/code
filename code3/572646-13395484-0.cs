        static bool IsUnparsedEntityReferenceError_BasedOnMessage(
            XmlSchemaException error)
        {
            return error != null && error.Message.StartsWith(
                "Reference to an unparsed entity", StringComparison.Ordinal);
        }
