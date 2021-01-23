    class Program
    {
        static void Main(string[] args)
        {
            string valid128BitString = "AAECAwQFBgcICQoLDA0ODw==";
            string inputValue = "MyTest";
            string keyValue = valid128BitString;
   
            //Turns our text in to binary data
            byte[] byteValForString = Encoding.UTF8.GetBytes(inputValue);
    
            EncryptResult result = Aes128Utility.EncryptData(byteValForString, keyValue);
            EncryptResult encyptedValue = new EncryptResult();
            
            //(Snip)
    
            encyptedValue.IV = resultingIV;
            encyptedValue.EncryptedMsg = result.EncryptedMsg;
    
            string finalResult = Encoding.UTF8.GetString(Aes128Utility.DecryptData(encyptedValue, keyValue));
            Console.WriteLine(finalResult);
    
            if (String.Equals(inputValue, finalResult))
            {
                Console.WriteLine("Match");
            }
            else
            {
                Console.WriteLine("Differ");
            }
    
            Console.ReadLine();
        }
    }
