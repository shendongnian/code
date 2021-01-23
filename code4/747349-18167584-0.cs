    public class A { int x,y,z; }
    public struct B { int x,y,z,w,a,b; }
    public struct C<T> { Guid g; T b,c,d,e,f; }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(IntPtr.Size); // on x86 == 4
            Console.WriteLine(SizeHelper.SizeOf(typeof(C<double>))); // prints 56 on x86
            Console.WriteLine(SizeHelper.SizeOf(typeof(C<int>))); // prints 36 on x86
        }
    }
    
    static class SizeHelper
    {
        private static Dictionary<Type, int> sizes = new Dictionary<Type, int>();
        
        public static int SizeOf(Type type)
        {
            int size;
            if (sizes.TryGetValue(type, out size))
            {
                return size;
            }
            
            size = SizeOfType(type);
            sizes.Add(type, size);
            return size;            
        }
        
        private static int SizeOfType(Type type)
        {
            var dm = new DynamicMethod("SizeOfType", typeof(int), new Type[] { });
            ILGenerator il = dm.GetILGenerator();
            il.Emit(OpCodes.Sizeof, type);
            il.Emit(OpCodes.Ret);
            return (int)dm.Invoke(null, null);
        }
    }
