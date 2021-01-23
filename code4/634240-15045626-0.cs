        private static readonly MethodInfo genericDefinitionOf_getData;
        static Foo() {
            Type prototypeQueryable = typeof(IQueryable<int>); 
            // this could be any IQuerable< something >
            // just had to choose one
            MethodInfo getData_ForInts = typeof(Foo).GetMethod(
                name: "GetData", 
                bindingAttr: BindingFlags.Static | BindingFlags.Public,
                binder: Type.DefaultBinder,
                types: new [] { prototypeQueryable, typeof(int), typeof(bool) },
                modifiers: null
            );
            // now we have the GetData<int>(IQueryable<int> data, int bar, bool bravo)
            // reffered by the reflection object getData_ForInts
            MethodInfo definition = getData_ForInts.GetGenericMethodDefinition();
            // now we have the generic (non-invokable) GetData<>(IQueryable<> data, int bar, bool bravo)
            // reffered by the reflection object definition
            Foo.genericDefinitionOf_getData = definition;
            // and we store it for future use
        }
