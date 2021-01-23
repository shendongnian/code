        public static IQueryable GetDataEx(IQueryable data, int bar, bool bravo) {
            if (null == data)
                throw new ArgumentNullException("data");
            // we can't honor null data parameters
            Type typeof_data = data.GetType(); // get the type (a class) of the data object
            Type[] interfaces = typeof.GetInterfaces(); // list it's interfaces
            var ifaceQuery = interfaces.Where(iface => 
                iface.IsGenericType && 
                (iface.GetGenericTypeDefinition() == typeof(IQueryable<>))
            ); // filter the list down to just those IQueryable<T1>, IQueryable<T2>, etc interfaces
            Type foundIface = ifaceQuery.SingleOrDefault();
            // hope there is at least one, and only one
            if (null == foundIface) // if we find more it's obviously not the time and place to make assumptions
                throw new ArgumentException("The argument is ambiguous. It either implements 0 or more (distinct) IQueryable<T> particularizations.");
              
            Type elementType = foundIface.GetGenericArguments()[0];
            // we take the typeof(T) out of the typeof(IQueryable<T>)
            MethodInfo getData_particularizedFor_ElementType = Foo.genericDefinitionOf_getData.MakeGenericMethod(elementType);
            // and ask the TypeSystem to make us (or find us) the specific particularization
            // of the **GetData < T >** method
            try {
              object result = getData_particularizedFor_ElementType.Invoke(
                  obj: null,
                  parameters: new object[] { data, bar, bravo }
              );
              // then we invoke it (via reflection)
              // and obliviously "as-cast" the result to IQueryable
              // (it's surely going to be ok, even if it's null)
              return result as IQueryable;
            } catch (TargetInvocationException ex) {
              // in case of any mis-haps we make pretend we weren't here
              // doing any of this
              throw ex.InnerException;
            }
        }
    }
