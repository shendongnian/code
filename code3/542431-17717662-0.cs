    public class Current
        {
            public static IPrincipal User
            {
                get
                {
                    return System.Threading.Thread.CurrentPrincipal;
                }
                set
                {
                    System.Threading.Thread.CurrentPrincipal = value;
                }
    
            }
        }
