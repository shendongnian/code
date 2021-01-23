      SomeClass someClass = new SomeClass{
            Property = "Value"
      };
      Expression<Func<object, object>> e = s => ((SomeClass)s).Property;
      string propName = ((MemberExpression)e.Body).Member.Name;
      object propValue = e.Compile().Invoke(someClass);
