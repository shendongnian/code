    // Jon Skeet explicitly disclaims any association with this horrible code.
    // THIS CODE IS FOR FUN ONLY. USING IT WILL INCUR WAILING AND GNASHING OF TEETH.
    using System;
    using System.Reflection.Emit;
    
    public class MyClass
    {
        public string Name { get{ return "David"; } }
    }
    
    
    class Test    
    {
        static void Main()
        {
            var method = typeof(MyClass).GetProperty("Name").GetGetMethod();
            var dynamicMethod = new DynamicMethod("Ugly", typeof(string), 
                                                  Type.EmptyTypes);
            var generator = dynamicMethod.GetILGenerator();
            generator.Emit(OpCodes.Ldnull);
            generator.Emit(OpCodes.Call, method);
            generator.Emit(OpCodes.Ret);
            var ugly = (Func<string>) dynamicMethod.CreateDelegate(
                           typeof(Func<string>));
            Console.WriteLine(ugly());
        }
    }
