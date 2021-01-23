     // Each blessed API will be annotated with a "__DynamicallyInvokableAttribute".
     // This "__DynamicallyInvokableAttribute" is a type defined in its own assembly.
     // So the ctor is always a MethodDef and the type a TypeDef.
     // We cache this ctor MethodDef token for faster custom attribute lookup.
     // If this attribute type doesn't exist in the assembly, it means the assembly
     // doesn't contain any blessed APIs.
     Type invocableAttribute = GetType("__DynamicallyInvokableAttribute", false);
     if (invocableAttribute != null)
     {
         Contract.Assert(((MetadataToken)invocableAttribute.MetadataToken).IsTypeDef);
    
         ConstructorInfo ctor = invocableAttribute.GetConstructor(Type.EmptyTypes);
         Contract.Assert(ctor != null);
    
         int token = ctor.MetadataToken;
         Contract.Assert(((MetadataToken)token).IsMethodDef);
    
         flags |= (ASSEMBLY_FLAGS)token & ASSEMBLY_FLAGS.ASSEMBLY_FLAGS_TOKEN_MASK;
     }
