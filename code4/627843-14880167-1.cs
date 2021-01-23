     if (modelType != null)
     {
         if (CompilerServices.IsAnonymousType(modelType))
         {
             type.CustomAttributes.Add(new CodeAttributeDeclaration(new CodeTypeReference(typeof(HasDynamicModelAttribute))));
         }
     }
