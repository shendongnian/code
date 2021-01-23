      private static void CloneObjectWithIL<T>(T source, T los)
        {
            var dynamicMethod = new DynamicMethod("Clone", null, new[] { typeof(T), typeof(T) });
            ILGenerator generator = dynamicMethod.GetILGenerator();
            foreach (var temp in typeof(T).GetProperties().Where(temp=>temp.CanRead&&temp.CanWrite))
            {
                generator.Emit(OpCodes.Ldarg_1);// los
                generator.Emit(OpCodes.Ldarg_0);// s
                generator.Emit(OpCodes.Callvirt,temp.GetMethod);
                generator.Emit(OpCodes.Callvirt, temp.SetMethod);
            }
            generator.Emit(OpCodes.Ret);
            var clone = (Action<T, T>) dynamicMethod.CreateDelegate(typeof(Action<T, T>));
            clone(source, los);
        }
