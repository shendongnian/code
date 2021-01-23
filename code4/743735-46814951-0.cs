        private static bool IsCollectionType(CodeType type, out CodeType elementType)
        {
            // string implements IEnumerable<char>, but we don't want to treat it as a collection
            if (type.FullName == "System.String")
            {
                elementType = null;
                return false;
            }
            var enumerable = type.Bases.OfType<CodeInterface>().FirstOrDefault(i => i.FullName.StartsWith("System.Collections.Generic.IEnumerable<"));
            var method = enumerable?.Members.OfType<CodeFunction>().FirstOrDefault(m => m.Name == "GetEnumerator");
            var enumerator = method?.Type.CodeType;
            var current = enumerator?.Members.OfType<CodeProperty>().FirstOrDefault(m => m.Name == "Current");
            if (current != null)
            {
                elementType = current.Type.CodeType;
                return true;
            }
            elementType = null;
            return false;
        }
