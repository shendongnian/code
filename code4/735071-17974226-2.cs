    using System;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    namespace Testbeispiel_Encryption
    {
    	public class MyDecryptor
    	{
    		public MyDecryptor()
    		{
    			//TODO Constructor
    		}
    		~MyDecryptor()
    		{
    			//TODO Destructor
    		}
     
    		///<summary>
    		///Opens certificate and private Key, Decrypts Data and returns the decrypted DocID
    		///</summary>
    		///<param name="pfxFilePath">The Filepath to the Certificate (.pfx) File!</param>
    		///<param name="password">The password for accessing the pfx file</param>
    		///<param name="EncryptedDocID">the Value of the encrypted Collumn, Encrypted by the Certifiate of the pfx File</param>
    		///<returns>string DecryptedDocID - the decrypted Value of the DocID</returns>
    		public string DecryptDocIDWithFileCert(string pfxFilePath, System.Security.SecureString password, byte[] EncryptedDocID)
    		{
    			//Reverse the encrypted DocID because SQL reverses the byte array on encryption
    			//and so does RSACryptoServiceProvider. 
    			Array.Reverse(EncryptedDocID);
    			string DecryptedDocID = "";
     
    			//load certificate from filesystem and open it with provided password
    			X509Certificate2 cert = new X509Certificate2(pfxFilePath, password);
    			if (cert == null)
    			{
    				throw new Exception("Certificate " + pfxFilePath + " Does not exist");
    			}
     
    			//Check if certificate has a private key, otherwhise we are unable to decrypt any message
    			//encrypted with the certs public key so we throw an exception
    			if (cert.HasPrivateKey)
    			{
    				RSACryptoServiceProvider RsaCSP = (RSACryptoServiceProvider)cert.PrivateKey;
    				//actualy decrypt message with RSACryptoServiceProvider and set OAEP Padding to false
    				//Don't know the reason, otherwhise it didn't work correctly 
    				byte[] ret = RsaCSP.Decrypt(EncryptedDocID, false);
    				if (ret == null)
    				{
    					throw new Exception("Decryption with RSA failed");
    				}
    				//Encode DocID to UTF7 String. UTF8 didn't recognise umlauts
    				DecryptedDocID = System.Text.Encoding.UTF7.GetString(ret);
    			}
    			else
    			{
    				throw new Exception("Certificate " + pfxFilePath + " has no Private Key; ");
    			}
    			return DecryptedDocID;
    		}
    	}
    }
