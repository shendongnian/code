      bool IsInstanceOfGenericTypeClosingTemplateOrSubclassThereof(object obj, Type genericTypeDefinition){ 
          if(obj == null) throw new ArgumentNullException("obj");
          if(genericTypeDefinition== null) throw new ArgumentNullException("genericTypeDefinition");
          if(!genericTypeDefinition.IsGenericTypeDefinition) throw new ArgumentException("Must be a generic type definition.", "genericTypeDefinition");
          
          Type type = obj.GetType();
          while ( type != typeof(object) )
          {
             if(type.IsGenericType && type.GetGenericTypeDefinition() == genericTypeDefinition) 
             {
                return true;
             }
             type = type.BaseType;
          } 
          return false;
      }
