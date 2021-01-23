    using System;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Interop;
    using System.Windows.Threading;
    using Xunit;
    
    namespace Boost.Utils.Testing.XUnit.WPF
    {
        /// <summary>helful if you stumble upon 'object disconnected from RCW' ComException *after* the test suite finishes,
        /// or if you are unable to start the test because the VS test runner tells you 'Unable to start more than one local run'
        /// even if all tests seem to have finished</summary>
        /// <remarks>only to be used with xUnit STA worker threads</remarks>
        [AttributeUsage(AttributeTargets.Method)]
        public class DomainNeedsDispatcherCleanupAttribute : BeforeAfterTestAttribute
        {
            public override void After(MethodInfo methodUnderTest)
            {
                base.After(methodUnderTest);
    
                Dispatcher.CurrentDispatcher.InvokeShutdown();
            }
        }
    }
