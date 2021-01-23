    public class SoupSession
    {
        [DllImport("webkit-1.0")]
        static extern IntPtr webkit_get_default_session();
    
        [DllImport("soup-2.4")]
        static extern IntPtr soup_uri_new(string uri);
    
        [DllImport("gobject-2.0")]
        static extern void g_object_set(IntPtr obj, string name, IntPtr value, IntPtr zero);
    
        public static void SetProxy(string uri)
        {
            IntPtr session = webkit_get_default_session();
            g_object_set(session, "proxy-uri", soup_uri_new(uri), IntPtr.Zero);
        }
    }
