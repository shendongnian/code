    class Foo
    {
        static void ThrowingMethod()
        {
            throw new NotImplementedException();
        }
    
        static MethodInfo GetMethodInfo()
        {
            return typeof(Foo)
                    .GetMethod("ThrowingMethod", BindingFlags.NonPublic | BindingFlags.Static);
        }
    
        // Will throw a NotImplementedException
        static void DelegateWay()
        {
            Action action = (Action)Delegate.CreateDelegate
                                        (typeof(Action), GetMethodInfo());
            action();
        }
    
        // Will throw a TargetInvocationException 
        // wrapping a NotImplementedException
        static void MethodInfoWay()
        {
            GetMethodInfo().Invoke(null, null);
        }
    }
