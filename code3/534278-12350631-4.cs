    using System;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web.Security;
    
    namespace SecurepayPaymentGatewayIntegrationIssue
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var text = @"ABC|password|1|Te‌​st Reference|1.00|20120912123421";
    			Console.WriteLine(GetSHA1String(text));
    
    			Console.WriteLine(FormsAuthentication.HashPasswordForStoringInConfigFile(text, "sha1").ToLower());
    
    			Console.ReadKey();
    		}
    
    		private static string GetSHA1String(string text)
    		{
    			var UE = new UTF8Encoding();// ASCIIEncoding(); // UnicodeEncoding();
    			var message = UE.GetBytes(text);
    
    			var hashString = new SHA1Managed();
    			var hex = string.Empty;
    
    			var hashValue = hashString.ComputeHash(message);
    			foreach (byte b in hashValue)
    			{
    				hex += String.Format("{0:x2}", b);
    			}
    
    			return hex;
    		}
    	}
    }
