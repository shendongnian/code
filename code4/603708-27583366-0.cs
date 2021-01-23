     Console.Write("Testing Encrypt/Decrypt using BigInteger ");
            string message2 = "Testing Some Data to Encrypt";
            byte[] buffer2 = Encoding.ASCII.GetBytes(message2);
            BigInteger m = new BigInteger(buffer2);
            BigInteger c = BigInteger.ModPow(m, E, M); //encrypt
            BigInteger m2 = BigInteger.ModPow(c, D, M); //decrypt, m2 also equals m
            byte[] decoded2 = m2.ToByteArray();
            
            if (decoded2[0] == 0) 
            {
                decoded2 = decoded2.Where(b => b != 0).ToArray();
            }
            string message3 = ASCIIEncoding.ASCII.GetString(decoded2);
    
            if (message2 == message3)
            {
                Console.WriteLine("Ok :)");
            }
            else
            {
                Console.WriteLine("Bad Encryption :(");
                Console.ReadKey();
                return;
            }
