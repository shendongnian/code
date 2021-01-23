    using System;
    using System.Security.Cryptography;
    using System.Text;
    
    class Test
    {
        static void Main()
        {
            String secretAccessKey = "mykey";
            String data = "my data";
            byte[] secretKey = Encoding.UTF8.GetBytes(secretAccessKey);
            HMACSHA256 hmac = new HMACSHA256(secretKey);
            hmac.Initialize();
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            byte[] rawHmac = hmac.ComputeHash(bytes);
            Console.WriteLine(Convert.ToBase64String(rawHmac));
        }
    }
