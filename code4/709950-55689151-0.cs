    using Microsoft.Win32;
    using System;
    using System.IO;
    using System.Security.Cryptography;
    
    namespace RsaCryptoExample
    {
    	class RSAFileHelper
    	{
    		readonly string pubKeyPath = "public.key";//change as needed
            readonly string priKeyPath = "private.key";//change as needed
            public void MakeKey()
            {
                //lets take a new CSP with a new 2048 bit rsa key pair
                RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
    
                //how to get the private key
                RSAParameters privKey = csp.ExportParameters(true);
    
                //and the public key ...
                RSAParameters pubKey = csp.ExportParameters(false);
                //converting the public key into a string representation
                string pubKeyString;
                {
                    //we need some buffer
                    var sw = new StringWriter();
                    //we need a serializer
                    var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                    //serialize the key into the stream
                    xs.Serialize(sw, pubKey);
                    //get the string from the stream
                    pubKeyString = sw.ToString();
                    File.WriteAllText(pubKeyPath, pubKeyString);
                }
                string privKeyString;
                {
                    //we need some buffer
                    var sw = new StringWriter();
                    //we need a serializer
                    var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                    //serialize the key into the stream
                    xs.Serialize(sw, privKey);
                    //get the string from the stream
                    privKeyString = sw.ToString();
                    File.WriteAllText(priKeyPath, privKeyString);
                }
            }
            public void EncryptFile(string filePath)
            {
                //converting the public key into a string representation
                string pubKeyString;
                {
                    using (StreamReader reader = new StreamReader(pubKeyPath)){pubKeyString = reader.ReadToEnd();}
                }
                //get a stream from the string
                var sr = new StringReader(pubKeyString);
                //we need a deserializer
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                //get the object back from the stream
                RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
                csp.ImportParameters((RSAParameters)xs.Deserialize(sr));
                byte[] bytesPlainTextData = File.ReadAllBytes(filePath);
                //apply pkcs#1.5 padding and encrypt our data 
                var bytesCipherText = csp.Encrypt(bytesPlainTextData, false);
                //we might want a string representation of our cypher text... base64 will do
                string encryptedText = Convert.ToBase64String(bytesCipherText);
                File.WriteAllText(filePath,encryptedText);
            }
            public void DecryptFile(string filePath)
            {
                //we want to decrypt, therefore we need a csp and load our private key
                RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
    
                string privKeyString;
                {
                    privKeyString = File.ReadAllText(priKeyPath);
                    //get a stream from the string
                    var sr = new StringReader(privKeyString);
                    //we need a deserializer
                    var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                    //get the object back from the stream
                    RSAParameters privKey = (RSAParameters)xs.Deserialize(sr);
                    csp.ImportParameters(privKey);
                }
                string encryptedText;
                using (StreamReader reader = new StreamReader(filePath)) { encryptedText = reader.ReadToEnd(); }
                byte[] bytesCipherText = Convert.FromBase64String(encryptedText);
    
                //decrypt and strip pkcs#1.5 padding
                byte[] bytesPlainTextData = csp.Decrypt(bytesCipherText, false);
    
                //get our original plainText back...
                File.WriteAllBytes(filePath, bytesPlainTextData);
            }
    	}
    }
