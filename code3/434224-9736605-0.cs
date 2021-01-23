    Thread jitter = new Thread(() =>
    {
       var flags = BindingFlags.DeclaredOnly | BindingFlags.NonPublic | 
                   BindingFlags.Public | BindingFlags.Instance | 
                   BindingFlags.Static;
       foreach (var assembly in AssembliesToPreload)
           foreach (var type in a.GetTypes())
               foreach (var method in type.GetMethods(flags))
               {
                    if (method.ContainsGenericParameters || 
                        method.IsGenericMethod || 
                        method.IsGenericMethodDefinition)
                        continue;
 
                    if ((method.Attributes & MethodAttributes.PinvokeImpl) > 0)
                        continue;
                    RuntimeHelpers.PrepareMethod(method.MethodHandle);
               }
       }
    });
    jitter.Priority = ThreadPriority.Lowest;
    jitter.Start();
