    using System;
    using System.Text;
    using System.Security.Cryptography;
    // Example code for using TransformBlock to hash data in chunks
    namespace HashTest
    {
        class HashTest
        {
            static void Main(string[] args)
            {
                SHA256 hash = SHA256.Create();
                ASCIIEncoding encoding = new ASCIIEncoding();
                string password = "password";
                // Hash a string using ComputeHash
                string sourcetext = password;
                Console.WriteLine(sourcetext);
                byte[] sourcebytes = encoding.GetBytes(sourcetext);
                byte[] hashBytes = hash.ComputeHash(sourcebytes);
                string hashStr = BitConverter.ToString(hashBytes).Replace("-", "");
                Console.WriteLine(hashStr);
                // Hash exactly two copies of a string
                // (used to cross verify other methods below).
                Console.WriteLine();
                sourcetext = password + password;
                Console.WriteLine(sourcetext);
                sourcebytes = encoding.GetBytes(sourcetext);
                hashBytes = hash.ComputeHash(sourcebytes);
                hashStr = BitConverter.ToString(hashBytes).Replace("-", "");
                Console.WriteLine(hashStr);
                // Hash a string using TransformFinalBlock
                Console.WriteLine();
                sourcetext = password;
                sourcebytes = encoding.GetBytes(sourcetext);
                Console.WriteLine(sourcetext);
                hash.TransformFinalBlock(sourcebytes, 0, sourcebytes.Length);
                hashBytes = hash.Hash;
                hashStr = BitConverter.ToString(hashBytes).Replace("-", "");
                Console.WriteLine(hashStr);
                // At this point we've finalized the hash. To
                // reuse it we must first call Initialize().
                // Hash string twice using TransformBlock / TransformFinalBlock
                Console.WriteLine();
                hash.Initialize();
                sourcetext = password;
                sourcebytes = encoding.GetBytes(sourcetext);
                Console.Write(sourcetext);
                hash.TransformBlock(sourcebytes, 0, sourcebytes.Length, null, 0);
                Console.WriteLine(sourcetext);
                hash.TransformFinalBlock(sourcebytes, 0, sourcebytes.Length);
                hashBytes = hash.Hash;
                hashStr = BitConverter.ToString(hashBytes).Replace("-", "");
                Console.WriteLine(hashStr);
                // Hash string twice using TransformBlock in a loop
                Console.WriteLine();
                hash.Initialize();
                sourcetext = password;
                sourcebytes = encoding.GetBytes(sourcetext);
                for (int i = 0; i < 2; ++i)
                {
                    Console.Write(sourcetext);
                    hash.TransformBlock(sourcebytes, 0, sourcebytes.Length, null, 0);
                }
                Console.WriteLine();
                hash.TransformFinalBlock(sourcebytes, 0, 0);
                hashBytes = hash.Hash;
                hashStr = BitConverter.ToString(hashBytes).Replace("-", "");
                Console.WriteLine(hashStr);
            }
        }
    }
