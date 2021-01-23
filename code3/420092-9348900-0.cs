    public class ProxyClass
    {
        public ProxyClass(string password, Action ac)
        {
            if (password == "111")
            {
                ac();
            }
        }
    }
