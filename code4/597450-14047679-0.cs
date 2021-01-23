        using System;
        using System.Security.Cryptography;
        using System.Text;
        namespace RSA
        {
            class Program
            {
                static void Main(string[] args)
                {
                    try
                    {
                        var rsaServer = new RSACryptoServiceProvider(1024);
                        var publicKeyXml = rsaServer.ToXmlString(false);
                        var rsaClient = new RSACryptoServiceProvider(1024);
                        rsaClient.FromXmlString(publicKeyXml);
                        var data = Encoding.UTF8.GetBytes("Data To Be Encrypted");
                        var encryptedData = rsaClient.Encrypt(data, false);
                        var decryptedData = rsaServer.Decrypt(encryptedData, false);
                        Console.WriteLine(Encoding.UTF8.GetString(decryptedData));
                        Console.WriteLine("OK");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.Read();
                }
            }
        }
