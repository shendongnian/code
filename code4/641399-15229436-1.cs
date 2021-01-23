    using Microsoft.Practices.Unity.InterceptionExtension;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace InterceptSetter
    {
        /// <summary>
        /// See http://msdn.microsoft.com/en-us/library/ff660871(v=pandp.20).aspx
        /// See http://msdn.microsoft.com/en-us/library/ff647107.aspx
        /// </summary>
        class SetterCallsFilterMethodBehavior : IInterceptionBehavior
        {
            public IEnumerable<Type> GetRequiredInterfaces()
            {
                // we dont need anything
                return new[] { typeof(ISomeObject) };
            }
    
            public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
            { // Do not intercept non-setter methods
                if (!input.MethodBase.Name.StartsWith("set_"))
                    return getNext()(input, getNext);
    
                IMethodReturn msg = getNext()(input, getNext);
    
                // post processing. this is where we call filter
                if (input.Target is ISomeObject)
                {
                    (input.Target as ISomeObject).Filter();
                }
    
                return msg;
            }
    
            /// <summary>
            /// We always execute
            /// </summary>
            public bool WillExecute
            {
                get { return true; }
            }
        }
    }
