    using System;
    using System.Runtime.CompilerServices;
    
    namespace DEMO
    {
        public sealed class EnumMapper<TKey, TValue> where TKey : struct, IConvertible
        {
            private struct FlaggedValue<T>
            {
                public bool flag;
                public T value;
            }
    
            private static readonly int size;
            private readonly Func<TKey, int> func;
            private FlaggedValue<TValue>[] flaggedValues;
    
            public TValue this[TKey key]
            {
                get
                {
                    int index = this.func.Invoke(key);
    
                    FlaggedValue<TValue> flaggedValue = this.flaggedValues[index];
    
                    if (flaggedValue.flag == false)
                    {
                        EnumMapper<TKey, TValue>.ThrowNoMappingException(); // Don't want the exception code in the method. Make this callsite as small as possible to promote JIT inlining and squeeze out every last bit of performance.
                    }
    
                    return flaggedValue.value;
                }
            }
    
            static EnumMapper()
            {
                Type keyType = typeof(TKey);
    
                if (keyType.IsEnum == false)
                {
                    throw new Exception("The key type [" + keyType.AssemblyQualifiedName + "] is not an enumeration.");
                }
    
                Type underlyingType = Enum.GetUnderlyingType(keyType);
    
                if (underlyingType != typeof(int))
                {
                    throw new Exception("The key type's underlying type [" + underlyingType.AssemblyQualifiedName + "] is not a 32-bit signed integer.");
                }
    
                var values = (int[])Enum.GetValues(keyType);
    
                int maxValue = 0;
    
                foreach (int value in values)
                {
                    if (value < 0)
                    {
                        throw new Exception("The key type has a constant with a negative value.");
                    }
    
                    if (value > maxValue)
                    {
                        maxValue = value;
                    }
                }
    
                EnumMapper<TKey, TValue>.size = maxValue + 1;
            }
    
            public EnumMapper(Func<TKey, int> func)
            {
                if (func == null)
                {
                    throw new ArgumentNullException("func",
                                                    "The func cannot be a null reference.");
                }
    
                this.func = func;
    
                this.flaggedValues = new FlaggedValue<TValue>[EnumMapper<TKey, TValue>.size];
            }
    
            public static EnumMapper<TKey, TValue> Construct(Func<TKey, int> func)
            {
                return new EnumMapper<TKey, TValue>(func);
            }
    
            public EnumMapper<TKey, TValue> Map(TKey key,
                                                TValue value)
            {
                int index = this.func.Invoke(key);
    
                FlaggedValue<TValue> flaggedValue;
    
                flaggedValue.flag = true;
                flaggedValue.value = value;
    
                this.flaggedValues[index] = flaggedValue;
    
                return this;
            }
            
            [MethodImpl(MethodImplOptions.NoInlining)]
            private static void ThrowNoMappingException()
            {
                throw new Exception("No mapping exists corresponding to the key.");
            }
        }
    }
