    public class Undergrad
    {
        public string Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Undergrad()
        {
            Id = KeyGenerator.GetUniqueKey();
        }
        public Undergrad(string firstName, string lastName)
            : this()
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
    public static class KeyGenerator
    {
        public static string GetUniqueKey()
        {
            int maxSize = 8;
            int minSize = 5;
            var chars = new char[62];
            string a;
            a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            chars = a.ToCharArray();
            int size = maxSize;
            var data = new byte[1];
            var crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            var result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b%(chars.Length - 1)]);
            }
            return result.ToString();
        }
