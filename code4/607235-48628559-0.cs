    //This code requires the Nu-get plugin ValueTuple
    using System.Diagnostics;
    
    public static class Extensions
    {
    
        [DebuggerHidden, DebuggerStepperBoundary]
        public static WaitCallback Bind(this Delegate @delegate, params object[] arguments)
        {
            return (@delegate, arguments).BoundVoid;
        }
    
        [DebuggerHidden, DebuggerStepperBoundary]
        public static Func<object, object> BindWithResult(this Delegate @delegate, params object[] arguments)
        {
            return (@delegate, arguments).BoundFunc;
        }
    
        [DebuggerHidden, DebuggerStepperBoundary]
        private static void BoundVoid(this object tuple, object argument)
        {
            tuple.BoundFunc(argument);
        }
    
        [DebuggerHidden, DebuggerStepperBoundary]
        private static object BoundFunc(this object tuple, object argument)
        {
            (Delegate @delegate, object[] arguments) = ((Delegate @delegate, object[] arguments))tuple;
            if (argument != null)
                if (!argument.GetType().IsArray)
                    argument = new object[] { argument };
            object[] extraArguments = argument as object[];
            object[] newArgs = extraArguments == null ? arguments : new object[arguments.Length + extraArguments.Length];
            if (extraArguments != null)
            {
                extraArguments.CopyTo(newArgs, 0);
                arguments.CopyTo(newArgs, extraArguments.Length);
            }
            if (extraArguments == null)
                return @delegate.DynamicInvoke(newArgs);
            object result = null;
            Exception e = null;
            int argCount = newArgs.Length;
            do
            {
                try
                {
                    if (argCount < newArgs.Length)
                    {
                        object[] args = newArgs;
                        newArgs = new object[argCount];
                        Array.Copy(args, newArgs, argCount);
                    }
                    result = @delegate.DynamicInvoke(newArgs);
                    e = null;
                } catch (TargetParameterCountException e2)
                {
                    e = e2;
                    argCount--;
                }
            } while (e != null);
            return result;
        }
    }
