    using System;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Runtime.InteropServices;
    
    namespace Network.Utils
    {
        public static class HttpApi
        {
            public unsafe static void SetRequestQueueLength(HttpListener listener, long len)
            {
                var listenerType = typeof (HttpListener);
                var requestQueueHandleProperty = listenerType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance).First(p => p.Name == "RequestQueueHandle");
                
                var requestQueueHandle = (CriticalHandle)requestQueueHandleProperty.GetValue(listener);
                var result = HttpSetRequestQueueProperty(requestQueueHandle, HTTP_SERVER_PROPERTY.HttpServerQueueLengthProperty, new IntPtr((void*)&len), (uint)Marshal.SizeOf(len), 0, IntPtr.Zero);
    
                if (result != 0)
                {
                    throw new HttpListenerException((int) result);
                }
            }
    
            internal enum HTTP_SERVER_PROPERTY
            {
                HttpServerAuthenticationProperty,
                HttpServerLoggingProperty,
                HttpServerQosProperty,
                HttpServerTimeoutsProperty,
                HttpServerQueueLengthProperty,
                HttpServerStateProperty,
                HttpServer503VerbosityProperty,
                HttpServerBindingProperty,
                HttpServerExtendedAuthenticationProperty,
                HttpServerListenEndpointProperty,
                HttpServerChannelBindProperty,
                HttpServerProtectionLevelProperty,
            }
    
            [DllImport("httpapi.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
            internal static extern uint HttpSetRequestQueueProperty(
                CriticalHandle requestQueueHandle,
                HTTP_SERVER_PROPERTY serverProperty,
                IntPtr pPropertyInfo,
                uint propertyInfoLength,
                uint reserved,
                IntPtr pReserved);         
        }
    }
