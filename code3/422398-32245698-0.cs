    using System;
    using System.Collections.Generic;
    using System.Runtime.Remoting.Messaging;
    using System.Runtime.Remoting.Proxies;
    
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace DotNetSandbox
    {
        // Subject interface to get names from
        interface IRequest
        {
            List<object> GetProfiles();
            void SetProfile(object p);
        }
    
        // Use case / Example:
        [TestClass]
        public class InterfaceNamesTests
        {
            [TestMethod]
            public void InterfaceNamesTest()
            {
                // Option 1 - Not strongly typed
                string name = typeof(IRequest).GetMethod("GetProfiles").Name;
                Console.WriteLine(name);    // OUTPUT: GetProfiles
    
                // Option 2 - Strongly typed!!
                var @interface = InterfaceNames<IRequest>.Create();
    
                Func<List<object>> func = @interface.GetProfiles;
                var name1 = func.Method.Name;
                Console.WriteLine(name1);   // OUTPUT: GetProfiles
    
                Action<object> action = @interface.SetProfile;
                var name2 = action.Method.Name;
                Console.WriteLine(name2);   // OUTPUT: SetProfile
    
                // Other options results with complex/unclear code.
            }
        }
    
        // Helper class
        public class InterfaceNames<T> : RealProxy
        {
            private InterfaceNames() : base(typeof(T)) { }
    
            public static T Create()
            {
                return (T)new InterfaceNames<T>().GetTransparentProxy();
            }
    
            public override IMessage Invoke(IMessage msg)
            {
                return null;
            }
        }
    }
