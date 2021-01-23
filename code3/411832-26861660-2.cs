    static buildCostItems()
            {
                //from http://blogs.msdn.com/b/haibo_luo/archive/2005/11/17/494009.aspx
                AssemblyBuilder asmBldr = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("inmemory"),
                                                                                        AssemblyBuilderAccess.Run);
                ModuleBuilder modBldr = asmBldr.DefineDynamicModule("helper");
                TypeBuilder typeBldr = modBldr.DefineType("ClassFactory");
                Type tci = typeof (CostsItem);
                IEnumerable<Type> types = Assembly.GetExecutingAssembly().GetTypes().Where(tci.IsAssignableFrom);
     //// Note -- assumption of currently executing assembly -- this isn't a requirement, but didn't need the dynamic callback capabilities of the Node constructor here.
                List<Type> enumerable = types as List<Type> ?? types.ToList();
                foreach (Type type in enumerable)
                {
                    MethodBuilder methBldr = typeBldr.DefineMethod(type.Name,
                                                                   MethodAttributes.Public | MethodAttributes.Static, type,
                                                                   new[] {typeof (CostsItem)});
                    ILGenerator ilgen = methBldr.GetILGenerator();
                    ilgen.Emit(OpCodes.Nop);
                    ilgen.Emit(OpCodes.Ldarg_0);
                    ilgen.Emit(OpCodes.Newobj, type.GetConstructor(new[] {typeof (CostsItem)}));
                    ilgen.Emit(OpCodes.Ret);
                }
                Type baked = typeBldr.CreateType();
                foreach (Type type in enumerable)
                    ctors.Add(type,
                              (CtorCloneDelegate)
                              Delegate.CreateDelegate(typeof (CtorCloneDelegate), baked.GetMethod(type.Name)));
            }
