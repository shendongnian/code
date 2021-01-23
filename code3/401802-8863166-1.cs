    class Program
    {
        static string[] addresses = new string[] 
            { "192.168.0.1", "215.100.100.100", "110.100.100.100" };
        static void Main(string[] args)
        {
            SmtpClient server1 = GetClient(0);
            // stuff to send mail with 1st server
            SmtpClient server2 = GetClient(1);
            // stuff to send mail with 2nd server
            // etc.
        }
        private static SmtpClient GetClient(int id)
        {
            if (addresses[id] != null)
                return new SmtpClient(addresses[id]);
            throw new ArgumentException("No such server");
        }
    }
