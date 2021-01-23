    public class CustomContractResolver : DefaultContractResolver
    {
        // For deserialization. Detect when the type is being deserialized and set the converter for it.
        public override JsonContract ResolveContract( Type type )
        {
            var contract = base.ResolveContract( type );
            if( contract.Converter == null && type.IsGenericType && type.GetGenericTypeDefinition() == typeof( Optional<> ) )
            {
                // This may look fancy but it's just calling GetOptionalJsonConverter<T> with the correct T
                var optionalValueType = type.GetGenericArguments()[ 0 ];
                var genericMethod = this.GetAndMakeGenericMethod( "GetOptionalJsonConverter", optionalValueType );
                var converter = (JsonConverter)genericMethod.Invoke( null, null );
                // Set the converter for the type
                contract.Converter = converter;
            }
            return contract;
        }
        public static OptionalJsonConverter<T> GetOptionalJsonConverter<T>()
        {
            return OptionalJsonConverter<T>.Instance;
        }
        // For serialization. Detect when we're creating a JsonProperty for an Optional<T> member and modify it accordingly.
        protected override JsonProperty CreateProperty( MemberInfo member, MemberSerialization memberSerialization )
        {
            var jsonProperty = base.CreateProperty( member, memberSerialization );
            var type = jsonProperty.PropertyType;
            if( type.IsGenericType && type.GetGenericTypeDefinition() == typeof( Optional<> ) )
            {
                // This may look fancy but it's just calling SetJsonPropertyValuesForOptionalMember<T> with the correct T
                var optionalValueType = type.GetGenericArguments()[ 0 ];
                var genericMethod = this.GetAndMakeGenericMethod( "SetJsonPropertyValuesForOptionalMember", optionalValueType );
                genericMethod.Invoke( null, new object[]{ member.Name, jsonProperty } );
            }
            return jsonProperty;
        }
        public static void SetJsonPropertyValuesForOptionalMember<T>( string memberName, JsonProperty jsonProperty )
        {
            if( jsonProperty.ShouldSerialize == null ) // Honor ShouldSerialize*
            {
                jsonProperty.ShouldSerialize =
                    ( declaringObject ) =>
                    {
                        if( jsonProperty.GetIsSpecified != null && jsonProperty.GetIsSpecified( declaringObject ) ) // Honor *Specified
                        {
                            return true;
                        }                    
                        object optionalValue;
                        if( !TryGetPropertyValue( declaringObject, memberName, out optionalValue ) &&
                            !TryGetFieldValue( declaringObject, memberName, out optionalValue ) )
                        {
                            throw new InvalidOperationException( "Better error message here" );
                        }
                        return ( (Optional<T>)optionalValue ).ValueProvided;
                    };
            }
            if( jsonProperty.Converter == null )
            {
                jsonProperty.Converter = CustomContractResolver.GetOptionalJsonConverter<T>();
            }
        }
        // Utility methods used in this class
        private MethodInfo GetAndMakeGenericMethod( string methodName, params Type[] typeArguments )
        {
            var method = this.GetType().GetMethod( methodName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static );
            return method.MakeGenericMethod( typeArguments );
        }
        private static bool TryGetPropertyValue( object declaringObject, string propertyName, out object value )
        {
            var propertyInfo = declaringObject.GetType().GetProperty( propertyName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance );
            if( propertyInfo == null )
            {
                value = null;
                return false;
            }
            value = propertyInfo.GetValue( declaringObject, BindingFlags.GetProperty, null, null, null );
            return true;
        }
        private static bool TryGetFieldValue( object declaringObject, string fieldName, out object value )
        {
            var fieldInfo = declaringObject.GetType().GetField( fieldName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance );
            if( fieldInfo == null )
            {
                value = null;
                return false;
            }
            value = fieldInfo.GetValue( declaringObject );
            return true;
        }
    }
