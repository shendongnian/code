    using System;
    using System.Reflection.Emit;
    public class Test
    {
        static void Main()
        {
            var dm = new DynamicMethod("foo", null, new[] {typeof(bool)});
            var il = dm.GetILGenerator();
            Label ex = il.BeginExceptionBlock();
            il.Emit(OpCodes.Ldarg_0);
            il.EmitCall(OpCodes.Call, typeof(Test).GetMethod("Throw"), null);
            il.Emit(OpCodes.Leave, ex);
            il.BeginCatchBlock(typeof(Exception));
            il.EmitCall(OpCodes.Call, typeof(Test).GetMethod("Log"), null);
            il.EndExceptionBlock();
            il.Emit(OpCodes.Ldstr, "done");
            il.EmitCall(OpCodes.Call, typeof(Console).GetMethod("WriteLine",
                          new[] {typeof(string)}), null);
            
            il.Emit(OpCodes.Ret);
            var act = (Action<bool>)dm.CreateDelegate(typeof (Action<bool>));
            Console.WriteLine("Expect success:");
            act(false);
            Console.WriteLine("Expect fail:");
            act(true);
            Console.WriteLine("(all done)");
        }
        public static void Throw(bool fatal)
        {
            if(fatal) throw new InvalidOperationException("Boom!");
        }
        public static void Log(Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
