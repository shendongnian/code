    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    
    namespace MyRedactedNamespace
    {
        /// <summary>
        /// Class responsible for exposing undocumented functionality making the host process unkillable.
        /// </summary>
        public static class ProcessProtection
        {
            [DllImport("ntdll.dll", SetLastError = true)]
            private static extern void RtlSetProcessIsCritical(UInt32 v1, UInt32 v2, UInt32 v3);
    
            /// <summary>
            /// Flag for maintaining the state of protection.
            /// </summary>
            private static volatile bool s_isProtected = false;
    
            /// <summary>
            /// For synchronizing our current state.
            /// </summary>
            private static ReaderWriterLockSlim s_isProtectedLock = new ReaderWriterLockSlim();
    
            /// <summary>
            /// Gets whether or not the host process is currently protected.
            /// </summary>
            public static bool IsProtected
            {
                get
                {
                    try
                    {
                        s_isProtectedLock.EnterReadLock();
    
                        return s_isProtected;
                    }
                    finally
                    {
                        s_isProtectedLock.ExitReadLock();
                    }
                }
            }
    
            /// <summary>
            /// If not alreay protected, will make the host process a system-critical process so it
            /// cannot be terminated without causing a shutdown of the entire system.
            /// </summary>
            public static void Protect()
            {
                try
                {
                    s_isProtectedLock.EnterWriteLock();
    
                    if(!s_isProtected)
                    {
                        System.Diagnostics.Process.EnterDebugMode();
                        RtlSetProcessIsCritical(1, 0, 0);
                        s_isProtected = true;
                    }
                }
                finally
                {
                    s_isProtectedLock.ExitWriteLock();
                }
            }
    
            /// <summary>
            /// If already protected, will remove protection from the host process, so that it will no
            /// longer be a system-critical process and thus will be able to shut down safely.
            /// </summary>
            public static void Unprotect()
            {
                try
                {
                    s_isProtectedLock.EnterWriteLock();
    
                    if(s_isProtected)
                    {
                        RtlSetProcessIsCritical(0, 0, 0);
                        s_isProtected = false;
                    }
                }
                finally
                {
                    s_isProtectedLock.ExitWriteLock();
                }
            }
        }
    }
