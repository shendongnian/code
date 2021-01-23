    using System;
    using System.Web;
    namespace Company.Product.Web.UI.Domain
    {
        public abstract class SessionBase<T> where T : class, new()
        {
            private static readonly Object _padlock = new Object();
            private static string Key
            {
                get { return typeof(SessionBase<T>).FullName; }
            }
            public static T Current
            {
                get
                {
                    var instance = HttpContext.Current.Session[Key] as T;
                    if (instance == null)
                    {
                        lock (SessionBase<T>._padlock)
                        {
                            if (instance == null)
                            {
                                HttpContext.Current.Session[Key] = 
                                  instance = new T();
                            }
                        }
                    }
                    return instance;
                }
            }
            public static void Clear()
            {
                var instance = HttpContext.Current.Session[Key] as T;
                if (instance != null)
                {
                    lock (SessionBase<T>._padlock)
                    {
                        HttpContext.Current.Session[Key] = null;
                    }
                }
            }
        }
    }
