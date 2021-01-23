    class Foo { static object target; }
    public void Call(ILGenerator il, Action action)
    {
        Foo.target = action.Target;
        il.Emit(OpCodes.Ldsfld, typeof(Foo).GetField("target");
        il.Emit(OpCodes.Callvirt, action.Method);
    }
