    public class AuthenticationTypeSurrogate : IDataContractSurrogate
    {
        public Type GetDataContractType(Type type)
        {
            // "Book" will be serialized as an object array
            // This method is called during serialization, deserialization, and schema export. 
            if (typeof(AuthenticationStructure).IsAssignableFrom(type))
            {
                return typeof(object[]);
            }
            return type;
        }
        public object GetObjectToSerialize(object obj, Type targetType)
        {
            // This method is called on serialization.
            if (obj is AuthenticationStructure)
            {
                AuthenticationStructure authenticationStructure = (AuthenticationStructure)obj;
                return new object[] { authenticationStructure.Username, authenticationStructure.Password, authenticationStructure.AppId };
            }
            return obj;
        }
        public object GetDeserializedObject(object obj, Type targetType)
        {
            // This method is called on deserialization.
            if (obj is object[])
            {
                object[] arr = (object[])obj;
                AuthenticationStructure authenticationStructure = new AuthenticationStructure { Username = (string)arr[0], Password = (string)arr[1], AppId = (int)arr[2] };
                return authenticationStructure;
            }
            return obj;
        }
        public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            return null; // not used
        }
        public System.CodeDom.CodeTypeDeclaration ProcessImportedType(System.CodeDom.CodeTypeDeclaration typeDeclaration, System.CodeDom.CodeCompileUnit compileUnit)
        {
            return typeDeclaration; // Not used
        }
        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            return null; // not used
        }
        public object GetCustomDataToExport(System.Reflection.MemberInfo memberInfo, Type dataContractType)
        {
            return null; // not used
        }
        public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
        {
            return; // not used
        }
    }
